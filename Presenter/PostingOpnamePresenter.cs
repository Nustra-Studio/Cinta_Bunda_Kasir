using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Repository;
using KasirApp.View;

namespace KasirApp.Presenter
{
    public class PostingOpnamePresenter
    {
        //Fields
        PostingOpnameRepo _repo;
        iPostingOpname _pos;

        //Constructor 
        public PostingOpnamePresenter(iPostingOpname pos)
        {
            _repo = new PostingOpnameRepo();
            _pos = pos;
        }

        //Method
        public void Posting()
        {
            _repo.PostOpname(_pos.tanggal);
        }
    }
}
