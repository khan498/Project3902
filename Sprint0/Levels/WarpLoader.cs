using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Warps;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuperMarioBrothers.Levels
{
    public class WarpLoader
    {
        private const string WARP_DIR = "./Level_Files";

        public WarpLoader()
        {
        }

        public void LoadWarps(ILevel level, string filename)
        {
            List<IWarp> warps = new List<IWarp>();

            StreamReader reader = new StreamReader(WARP_DIR + "/" + filename);

            int numWarps = Convert.ToInt32(reader.ReadLine());

            for (int i = 0; i < numWarps; i++)
            {
                string[] temp = reader.ReadLine().Split(',');
                Vector2 start = new Vector2(
                    Convert.ToInt32(temp[0]) * DataLibrary.DEFAULT_SIZE, 
                    (level.Height * DataLibrary.DEFAULT_SIZE) - Convert.ToInt32(temp[1]) * DataLibrary.DEFAULT_SIZE
                );
                Vector2 end = new Vector2(
                    Convert.ToInt32(temp[2]) * DataLibrary.DEFAULT_SIZE,
                    (level.Height * DataLibrary.DEFAULT_SIZE) - Convert.ToInt32(temp[3]) * DataLibrary.DEFAULT_SIZE
                );

                level.Warps.Add(new PipeWarp(start, end));
            }
            reader.Close();
        }

    }
}
