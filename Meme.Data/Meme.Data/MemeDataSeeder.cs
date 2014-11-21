using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme.Data
{
    public class MemeDataSeeder
    {
        MemeContext _ctx;
        public MemeDataSeeder(MemeContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            if (_ctx.Memes.Count() > 0)
            {
                return;
            }
            for (int i = 0; i < Memes.Length; i++)
            {
                var mameDetails = Memes[i].Split(',');

                var meme = new Meme
                {
                    Title = mameDetails[0],
                    ImageUrl = mameDetails[1],
                    Description = mameDetails[2],
                    Genre = mameDetails[3]
                };
                _ctx.Memes.Add(meme);
            }
        }

        static string[] Memes =
        {
        "Meme1,Image1.gif,Memedesc1,MemeGenre1",
        "Meme2,Image2.gif,Memedesc2,MemeGenre2",
        "Meme3,Image3.gif,Memedesc3,MemeGenre3",
        "Meme4,Image4.gif,Memedesc4,MemeGenre4"
        };

    }
}
