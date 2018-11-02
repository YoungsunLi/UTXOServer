using RocksDbSharp;
using Newtonsoft.Json.Linq;

namespace UTXOServer {
    class RocksDB {
        readonly private static DbOptions options = new DbOptions().SetCreateIfMissing(true);
        readonly private static string path = "D://dbtest";//数据库位置
        readonly private static RocksDb db = RocksDb.Open(options, path);


        /*
        Put(byte[] key, byte[] value);
        Put(string key, string value);
        Put(byte[] key, long keyLength, byte[] value, long valueLength);

        Get(byte[] key, byte[] buffer, long offset, long length);----------long
        Get(string key);----------string
        Get(byte[] key, long keyLength, byte[] buffer, long offset, long length);----------long
        Get(byte[] key, long keyLength);----------byte[]
        Get(byte[] key);----------byte[]

        Remove(byte[] key);
        Remove(string key);
        Remove(byte[] key, long keyLength);
        */

        //Put
        public void Put(string txid, int n, string blockIndex, string asset, string address, string value) {
            string key = txid + n;
            string utxo = "{\"blockIndex\":\"" + blockIndex + "\",\"asset\":\"" + asset + "\",\"address\":\"" + address + "\",\"value\":\"" + value + "\"}";
            db.Put(key, utxo);
        }
        public void Put(byte[] key, byte[] value) {
            db.Put(key, value);
        }
        public void Put(string key, string value) {
            db.Put(key, value);
        }
        public void Put(byte[] key, long keyLength, byte[] value, long valueLength) {
            db.Put(key, keyLength, value, valueLength);
        }

        //Get
        public JObject Get(string txid, string n) {
            return JObject.Parse(db.Get(txid + n));
        }
        public long Get(byte[] key, byte[] buffer, long offset, long length) {
            return db.Get(key, buffer, offset, length);
        }
        public string Get(string key) {
            return db.Get(key);
        }
        public long Get(byte[] key, long keyLength, byte[] buffer, long offset, long length) {
            return db.Get(key, keyLength, buffer, offset, length);
        }
        public byte[] Get(byte[] key, long keyLength) {
            return db.Get(key, keyLength);
        }
        public byte[] Get(byte[] key) {
            return db.Get(key);
        }

        //Remove
        public void Remove(string txid, int n) {
            db.Remove(txid + n);
        }
        public void Remove(byte[] key) {
            db.Remove(key);
        }
        public void Remove(string key) {
            db.Remove(key);
        }
        public void Remove(byte[] key, long keyLength) {
            db.Remove(key, keyLength);
        }
    }
}
