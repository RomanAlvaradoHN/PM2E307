using Firebase.Database;
using Firebase.Database.Query;

using PM2E307.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2E307.Controllers {
    public class FirebaseController {
        private readonly string url = "https://pm2e307-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient client;
        private string deleteBugRecord;


        public FirebaseController() {
            this.client = new FirebaseClient(url);
        }




        public async Task<int> NewId<T>(T table) {
            List<T> lista = new List<T>();
            var dataList = await client.Child(typeof(T).Name).OnceAsync<T>();
            foreach (var dl in dataList) {
                lista.Add(dl.Object);
            }

            if(lista.Count == 0) {
                deleteBugRecord = (await client.Child(typeof(T).Name).PostAsync(table)).Key;
                return 2;
            }

            return (lista.Count + 1);            
        }



        //CREATE =====================================================================
        public async Task Insert<T>(T model) {
            string newId = (await NewId(model)).ToString();
            await client.Child(typeof(T).Name).Child(newId).PutAsync(model);

            /*
            if (!string.IsNullOrEmpty(deleteBugRecord)) {
                await client.Child(typeof(T).Name).Child(deleteBugRecord).DeleteAsync();
                deleteBugRecord = string.Empty;
            }
            */
        }




        //READ ALL =================================================================
        public async Task<List<T>> SelectAllFrom<T>(T table) {
            List<T> lista = new List<T>();
            var dataList = await client.Child(typeof(T).Name).OnceAsync<T>();
            foreach (var dl in dataList){
                lista.Add(dl.Object);
            }
            return lista;
        }



        //READ BY ID =================================================================
        public async Task<T> SelectById<T>(int id, T table) {
            return await client.Child(typeof(T).Name).Child(id.ToString()).OnceSingleAsync<T>();
        }




        //UPDATE =====================================================================
        public async void Update<T>(int id, T data) {
            await client.Child(typeof(T).Name).Child(id.ToString()).PutAsync(data);
        }





        //DELETE =====================================================================
        public async void Delete<T>(int id, T data) {
            await client.Child(typeof(T).Name).Child(id.ToString()).DeleteAsync();
        }


    }
}
