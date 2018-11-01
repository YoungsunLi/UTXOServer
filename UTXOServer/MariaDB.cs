using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace UTXOServer {
    class MariaDB {
        MySqlConnection sqlConnection = new MySqlConnection();

        //根据address asset查询utxo
        public MySqlDataReader GetUTXO(string address, string asset) {
            string cmd =
                "select txid,n,address,asset,value "
                + "from vout "
                + "where id not in "
                + "(select vout.id "
                + "from vout vout "
                + "join vin vin "
                + "on vin.txidRef= vout.txid and vin.nRef= vout.n) "
                + "and[address] = '" + address + "' "
                + "and asset= '" + asset + "'";
            MySqlDataReader MySqlDataReader = CommandReader(cmd);
            return MySqlDataReader;
        }

        //根据address查询utxo
        public MySqlDataReader GetUTXO(string address) {
            string cmd =
                "select txid,n,address,asset,value "
                + "from vout "
                + "where id not in "
                + "(select vout.id "
                + "from vout vout "
                + "join vin vin "
                + "on vin.txidRef= vout.txid and vin.nRef= vout.n) "
                + "and[address] = '" + address + "'";
            MySqlDataReader MySqlDataReader = CommandReader(cmd);
            return MySqlDataReader;
        }

        //更新高度
        public void UpdateBlockHeight(long blockNum) {
            string cmd = "update blockHeight set blockHeight=" + blockNum + " where net='testnet'";
            CommandNonQuery(cmd);
        }

        //储存vout
        public void AddVout(string blockIndex, string txid, int n, string asset, string address, string value) {
            string cmd = "insert into vout(blockIndex, txid, n, asset, address, value)values('" + blockIndex + "','" + txid + "','" + n + "','" + asset + "','" + address + "','" + value + "')";
            CommandNonQuery(cmd);
        }
        //储存vout
        public void AddVin(string blockIndex, string txidRef, int nRef) {
            string cmd = "insert into vin(blockIndex, txidRef, nRef)values('" + blockIndex + "','" + txidRef + "','" + nRef + "')";
            CommandNonQuery(cmd);
        }

        //获取上次爬到的高度
        public long GetStartBlock() {
            string cmd = "select blockHeight from blockHeight where net='testnet'";
            MySqlDataReader MySqlDataReader = CommandReader(cmd);
            if(MySqlDataReader.Read()) {
                try {
                    return (long)MySqlDataReader["blockHeight"];
                } catch(Exception) {
                    return 0;
                }
            } else {
                return 0;
            }
        }

        //有返回结果的查询
        private MySqlDataReader CommandReader(string cmd) {
            MySqlCommand MySqlCommand = new MySqlCommand(cmd, sqlConnection);
            MySqlDataReader MySqlDataReader = MySqlCommand.ExecuteReader();
            return MySqlDataReader;
        }

        //仅查询
        private void CommandNonQuery(string cmd) {
            MySqlCommand MySqlCommand = new MySqlCommand(cmd, sqlConnection);
            MySqlCommand.ExecuteNonQuery();
        }

        //连接数据库
        public void Open() {
            sqlConnection.ConnectionString = "server=127.0.0.1; user id=root; password=lsun.net; database=test";
            sqlConnection.Open();
            if(sqlConnection.State == ConnectionState.Closed) { Console.WriteLine("sqlConnection error"); }
        }

        //关闭数据库
        public void Close() {
            sqlConnection.Close();
        }
    }
}