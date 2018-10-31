using System;
using System.Collections.Generic;
using System.Text;

namespace UTXOServer {
    class RocksDB {
        /*
        Put(byte[] key, byte[] value);
        Put(string key, string value);
        Put(byte[] key, long keyLength, byte[] value, long valueLength);

        Get(byte[] key, byte[] buffer, long offset, long length);----------long
        Get(string key);----------string
        Get(byte[] key, long keyLength, byte[] buffer, long offset, long length);----------long
        Get(byte[] key, long keyLength);####byte[]
        Get(byte[] key);----------byte[]

        Remove(byte[] key);
        Remove(string key);
        Remove(byte[] key, long keyLength);
        */

        public void Put(byte[] key, byte[] value) {

        }
        public void Put(string key, string value) {

        }
        public void Put(byte[] key, long keyLength, byte[] value, long valueLength) {

        }
        public long Get(byte[] key, byte[] buffer, long offset, long length) {
            return 0;
        }
        public string Get(string key) {
            return "";
        }
        public long Get(byte[] key, long keyLength, byte[] buffer, long offset, long length) {
            return 0;
        }
        public byte[] Get(byte[] key, long keyLength) {
            return null;
        }
        public byte[] Get(byte[] key) {
            return null;
        }

        public void Remove(byte[] key) {

        }
        public void Remove(string key) {

        }
        public void Remove(byte[] key, long keyLength) {

        }
    }
}
