using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul10_10302230099.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        public class Mahasiswa
        {
            public string Nama { get; set; }
            public string Nim { get; set; }
        }

        public static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Sheila Nabilla ChantikaYudho", Nim = "103022300099" },
            new Mahasiswa { Nama = "Alya Rahmadayani Supriadi", Nim = "103022300160" },
            new Mahasiswa { Nama = "Riyanda Wiesya Bella", Nim = "103022300001" },
            new Mahasiswa { Nama = "Shinta Alya Aulya Ningrum", Nim = "103022300049" }
            
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return mahasiswaList;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswaBaru)
        {
            mahasiswaList.Add(mahasiswaBaru);
            return Ok(mahasiswaBaru);
        }
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();
            return mahasiswaList[index];
        }
        [HttpDelete("{index}")] 
        public ActionResult Delete(int index) 
        {
            if (index >= 0 && index < mahasiswaList.Count)
            {
                Mahasiswa mahasiswaDihapus = mahasiswaList[index];
                mahasiswaList.RemoveAt(index);
                return Ok($"Mahasiswa dengan NIM {mahasiswaDihapus.Nim} pada indeks {index} berhasil dihapus.");
            }
            else
            {
                return NotFound($"Mahasiswa dengan indeks {index} tidak ditemukan.");
            }
        }
    }
    }

