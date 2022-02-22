using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using MusicApi.Data;
using System.Linq;

namespace MusicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController:ControllerBase
    {
        private readonly ApiDBContext _db;
        public SongsController(ApiDBContext db)
        {
            _db=db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Song>> GetAllSongs()
        {
            return Ok(_db.Songs);
        }

        [HttpPost]
        public ActionResult InsertSongs([FromBody]List<Song> newSongs)
        {    
            foreach(var nwsong in newSongs)
            {
                 _db.Songs.Add(nwsong);
            }           
            _db.SaveChanges();
            return Ok(newSongs.Count.ToString()+" records inserted");
        }

        [HttpGet("{language}")]
         public ActionResult<IEnumerable<Song>> GetSongsBylang(string language)
        {   
           var songByLang = _db.Songs
                        .Where(l => l.Language==language) 
                        .AsEnumerable();
                        return Ok(songByLang); // Start using LINQ to Objects (switch to client evaluation)
    
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSongById(int id,[FromBody]Song song)
        {
            var newSong=_db.Songs.Find(id);
            if(newSong !=null)
            {
                newSong.Language=song.Language;
                newSong.Title=song.Title;
                 _db.SaveChanges();
                return Ok("Song ID found");                

            }
            else
            {
                return BadRequest("Song Id not found");
            }
            
        }

       /* [HttpPut,ActionName("{language}")]
        public ActionResult<IEnumerable<Song>> UpdateSongByLang(string language,[FromBody]Song song)
        {
            var newSongs=_db.Songs
            .Where(ln=>ln.Language==language).ToList();

            if(newSongs !=null)
            {
                foreach(var sn in newSongs)
                {
                //sn.Language=song.Language;
                sn.Title=song.Title;
                }
               /* newSong.Language=song.Language;
                newSong.Title=song.Title;
                 _db.SaveChanges();
                 //return newSongs;//_db.Songs;
                return Ok("records updated : "+newSongs.Count);                

            }
            else
            {
                return BadRequest("language not found");
            }
            
        }
        */
    }
}