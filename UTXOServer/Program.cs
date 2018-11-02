using System;

namespace UTXOServer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            SyncBlock syncBlock = new SyncBlock();
            RocksDB rocksDB = new RocksDB();
            MariaDB mariaDB = new MariaDB();
            ///rocksDB.Put("txid", 1, "index", "asset", "address", "100000000");
            //mariaDB.Open();
            syncBlock.Run();
            Console.ReadKey();
        }
    }
}
