using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kucia.sprog.Programmer
{
    public class PageOfCode
    {
        public List<byte> code;
        public UInt16 number;
        public PageOfCode()
        {
            this.code = new List<byte>();
        }
    }

    public class PagesOfCode
    {
        public PageOfCode[] Pages;

        public UInt16 PageCount
        {
            get { return (UInt16)this.Pages.Length; }
        }

        public PagesOfCode(int pages)
        {
            this.Pages = new PageOfCode[pages];
        }

        public void InsertPage(PageOfCode page, int pageNumber)
        {
            foreach (byte b in page.code)
            {
                if (b != 0xFF) //TODO
                {
                    if (Pages[pageNumber] == null)
                    {
                        page.number = (ushort)pageNumber;
                        Pages[pageNumber] = page;
                        return;
                    }
                    else
                        throw new Exception("Cannot insert page on existing one.");
                }
            }
        }
    }
}


////////////////////////////////////////////////////////////////////////////////////////////
//EOF