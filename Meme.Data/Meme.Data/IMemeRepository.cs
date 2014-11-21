using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme.Data
{
    public interface  IMemeRepository
    {
        IQueryable<Meme> GetAllMemes();
        Meme GetMeme(int MemeId);
        bool InsertMeme(Meme mame);
        bool UpdateMeme(Meme originalMeme, Meme updatedMeme);
        bool DeleteMeme(int id);

        bool Save();

   }
}
