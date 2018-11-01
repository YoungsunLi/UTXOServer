using RocksDbSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTXOServer {
    class RocksDB {
        readonly private DbOptions options = new DbOptions().SetCreateIfMissing(true);
        readonly private string path = "db";//数据库位置

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
        public void Put(byte[] key, byte[] value) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                db.Put(key, value);
            }
        }
        public void Put(string key, string value) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                db.Put(key, value);
            }
        }
        public void Put(byte[] key, long keyLength, byte[] value, long valueLength) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                db.Put(key, keyLength, value, valueLength);
            }
        }

        //Get
        public long Get(byte[] key, byte[] buffer, long offset, long length) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                return db.Get(key, buffer, offset, length);
            }
        }
        public string Get(string key) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                return db.Get(key);
            }
        }
        public long Get(byte[] key, long keyLength, byte[] buffer, long offset, long length) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                return db.Get(key, keyLength, buffer, offset, length);
            }
        }
        public byte[] Get(byte[] key, long keyLength) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                return db.Get(key, keyLength);
            }
        }
        public byte[] Get(byte[] key) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                return db.Get(key);
            }
        }

        //Remove
        public void Remove(byte[] key) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                db.Remove(key);
            }
        }
        public void Remove(string key) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                db.Remove(key);
            }
        }
        public void Remove(byte[] key, long keyLength) {
            using(RocksDb db = RocksDb.Open(options, path)) {
                db.Remove(key, keyLength);
            }
        }
    }
}
