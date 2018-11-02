using System;
using System.Text;
using Newtonsoft.Json.Linq;

namespace UTXOServer {
    class SyncBlock {
        RocksDB rocksDB = new RocksDB();
        public void Run() {
            long startBlock = GetStartBlock();
            long endBlock = GetEndBlock();

            //同步主循环
            for(long blockNum = startBlock; blockNum < endBlock; blockNum++) {
                //获取块信息
                JObject blockJson = GetBlock(blockNum);
                //遍历tx 处理vin vout
                foreach(JObject tx in blockJson["result"]["tx"]) {
                    //接收index
                    string blockindex = blockJson["result"]["index"].Value<string>();
                    //接收txid
                    string txid = tx["txid"].Value<string>();
                    //处理vin
                    foreach(JObject vin in tx["vin"]) {
                        string txidRef = vin["txid"].Value<string>();
                        int nRef = vin["vout"].Value<int>();
                        //删库
                        rocksDB.Remove(txidRef, nRef);
                        Console.WriteLine(blockindex + txidRef + nRef);
                    }

                    //处理vout
                    foreach(JObject vout in tx["vout"]) {
                        int n = vout["n"].Value<int>();
                        string asset = vout["asset"].Value<string>();
                        string address = vout["address"].Value<string>();
                        string value = vout["value"].Value<string>();
                        //入库
                        rocksDB.Put(txid, n, blockindex, asset, address, value);
                        Console.WriteLine(txid + n + blockindex + asset + address + value);
                    }
                }
                //记录更新
                rocksDB.Put("blockHeight", (blockNum + 1).ToString());
            }
        }
        HttpRequest httpRequest = new HttpRequest();
        //获取块信息
        private JObject GetBlock(long blockNum) {
            JObject blockJson = httpRequest.GetBlock(blockNum);
            Console.Write(" " + blockNum);
            return blockJson;
        }

        //获取起始块
        private long GetStartBlock() {
            string blockHeight = rocksDB.Get("blockHeight");
            if(blockHeight == null || blockHeight == "") {
                blockHeight = "0";
            }
            long startBlock = long.Parse(blockHeight);
            return startBlock;
        }

        //获取最高块
        private long GetEndBlock() {
            JObject json = httpRequest.Get("getblockcount", "");
            long endBlock = json["result"].Value<long>();
            return endBlock;
        }
    }
}
