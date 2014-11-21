using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Meme.Data
{
    public class MemeRepository : IMemeRepository
    {

        private MemeContext _ctx;

        public MemeRepository(MemeContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Meme> GetAllMemes()
        {
            return _ctx.Memes.AsQueryable();
        }

        public Meme GetMeme(int MemeId)
        {
            return _ctx.Memes.Find(MemeId);
        }

        public bool InsertMeme(Meme meme)
        {
            try
            {
                _ctx.Memes.Add(meme);
                return true;
            }
            catch
            {
                return false;
            }
        }

       public bool UpdateMeme(Meme originalMeme, Meme updatedMeme)
       {
           _ctx.Entry(originalMeme).CurrentValues.SetValues(updatedMeme);
            return true;
       }


        public bool DeleteMeme(int id)
        {
           
            var entity = _ctx.Memes.Find(id);
            if (entity != null)
            {
                _ctx.Memes.Remove(entity);
                return true;
            }
           
            return false;
         }

        public bool Save()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
