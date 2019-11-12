using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kucia.sprog.Programmer
{
    public class Importer
    {
        public static PagesOfCode ImportRawBinary(string filename, int pagesize)
        {

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            PagesOfCode poc = new PagesOfCode((int)(1 + (fs.Length / pagesize)));

            try
            {
                int byteCounter = pagesize;
                int pageNumber = 0;
                PageOfCode page = new PageOfCode();

                //Analiza każdej linii
                while (fs.Position != fs.Length)
                {
                    byteCounter--;
                    page.code.Add((byte)fs.ReadByte());
                    if (byteCounter == 0)
                    {
                        poc.InsertPage(page, pageNumber);
                        pageNumber++;
                        byteCounter = pagesize;
                        page = new PageOfCode();
                    }
                }
                if (byteCounter != 0)
                {
                    while (byteCounter != 0)
                    {
                        page.code.Add(0x00);
                        byteCounter--;
                    }
                    poc.InsertPage(page, pageNumber);
                }
            }
            catch (Exception exc)
            {
                fs.Close();
                throw new Exception("File read error:" + exc.Message);
            }

            fs.Close();
            return poc;
        }

        public static PagesOfCode ImportRawBinaryDiff(string oldFile, string newFile, int pagesize)
        {
            FileStream oldF = new FileStream(oldFile, FileMode.Open, FileAccess.Read, FileShare.None);
            FileStream newF = new FileStream(newFile, FileMode.Open, FileAccess.Read, FileShare.None);

            PagesOfCode poc = new PagesOfCode((int)(1 + (newF.Length / pagesize)));

            try
            {
                int pageNumber = 0;
                List<byte> buffer = new List<byte>(pagesize);
                bool diff = false;

                //Analiza każdego bajtu nowego pliku
                while (newF.Position != newF.Length)
                {

                    for (int i = 0; i < pagesize; i++)
                    {
                        int newB = newF.ReadByte();
                        int oldB = oldF.ReadByte();

                        if (newB == -1)
                        {
                            //Dopełnienie strony
                            buffer.Add(0x00);
                        }
                        else
                            if (oldB == -1)
                            {
                                buffer.Add((byte)newB);
                            }
                            else
                            {
                                if (newB != oldB)
                                    diff = true;
                                buffer.Add((byte)newB);
                            }

                        if (buffer.Count == pagesize)
                        {
                            if (diff)
                            {
                                PageOfCode page = new PageOfCode();
                                page.code = buffer;
                                poc.InsertPage(page, pageNumber);
                            }
                            pageNumber++;
                            buffer = new List<byte>(pagesize);
                            diff = false;
                        }
                    }
                }
                if (buffer.Count != 0)
                {
                    for (int i = 0; i < (pagesize - buffer.Count); i++)
                        buffer.Add(0x00);
                        PageOfCode page = new PageOfCode();
                        page.code = buffer;
                        poc.InsertPage(page, pageNumber);
                }
            }
            catch (Exception exc)
            {
                newF.Close();
                oldF.Close();
                throw new Exception("Files read error:" + exc.Message);
            }

            newF.Close();
            oldF.Close();
            return poc;
        }

    }
}
