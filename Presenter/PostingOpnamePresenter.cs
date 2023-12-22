using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using KasirApp.Repository;
using KasirApp.View;

namespace KasirApp.Presenter
{
    public class PostingOpnamePresenter
    {
        //Fields
        PostingOpnameRepo _repo;
        userDataModel _user;
        iPostingOpname _pos;

        //Constructor 
        public PostingOpnamePresenter(iPostingOpname pos, userDataModel user)
        {
            _repo = new PostingOpnameRepo();
            _pos = pos;
            _user = user;
        }

        //Method
        public void Posting()
        {
            _repo.PostOpname(_pos.tanggal, _user);
        }
    }
}
