using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Exercise03 {

    // List 17-8
    public abstract class TextProcessor {

        public static void Run< T >( string fileName ) where T : TextProcessor, new() {

            var self = new T();
            self.Process( fileName );

        }


        private void Process( string fileName ) {

            Initialize( fileName );       //初期化処理
            using ( var sr = new StreamReader( fileName ) ) {

                while ( !sr.EndOfStream ) {

                    string line = sr.ReadLine();
                    Execute( line );      //メイン処理

                }

            }

            Terminate();        //後処理

        }

        protected virtual void Initialize( string fname ) { }
        protected virtual void Execute( string line ) { }
        protected virtual void Terminate() { }

    }

}
