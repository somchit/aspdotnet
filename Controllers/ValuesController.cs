using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace aspdotnet.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public string Get()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=10.1.201.11;Initial Catalog=test;User ID=sa;Password=p@ssw0rd";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                // MessageBox.Show("Connection Open ! ");
                var command = new SqlCommand("select * from customer", cnn);
                var dataReader = command.ExecuteReader();
                var str = "[";
                while (dataReader.Read())
                {
                    str += "{";
                    str += "id:" + dataReader.GetValue(0).ToString();
                    str += ",name:'" + dataReader.GetValue(1).ToString()+"'";
                    str += ",surname:'" + dataReader.GetValue(2).ToString()+"'";


                    str += "}";
                    //MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                }
                str += "]";
                command.Dispose();
                cnn.Close();
                return str;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Can not open connection ! ");
                return "{error:'"+ex.Message+"'}";
            }

           // return "{error:1}";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
