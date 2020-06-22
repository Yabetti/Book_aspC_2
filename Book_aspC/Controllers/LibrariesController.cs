using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book_aspC.Models;

namespace Book_aspC.Controllers
{
    public class LibrariesController : Controller
    {
        private LibraryDBContext db = new LibraryDBContext();
        private UserDBContext user_db = new UserDBContext();


        //ログイン画面 + デフォルト画面
        public ActionResult Login()
        {
            return View();
        }

        //エラー画面
        public ActionResult Common_error()
        {
            return View();
        }

        //お問い合わせ画面
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Libraries
        //param:usernameログインユーザネーム
        //     :passwordログインユーザパスワード
        //     :searchString 検索用単語
        //[Authorize]
        public ActionResult Index(String username ,String password, String searchString)
        {
            //ログイン画面からの遷移かチェック
            if ((!String.IsNullOrEmpty(username)) && (!String.IsNullOrEmpty(password)))
            {
                //ログインチェック処理
                foreach(User user_info in user_db.Users.ToList())
                {
                    if ((username == user_info.Username) && (password == user_info.Userpassword))
                    {
                        return View(db.Libraries.ToList());
                    }
                    else
                    {
                        return RedirectToAction("Common_error");
                    }
                }
            }


            //ログイン画面以外からの遷移処理
            if (String.IsNullOrEmpty(searchString))
            {
                //全件返す
                return View(db.Libraries.ToList());
            }
            //本一覧情報取得
            var lib_list = from book in db.Libraries
                           select book;
            //一致するレコードの抽出
            lib_list = lib_list.Where(b => b.Title.Contains(searchString));
            
            return View(lib_list);
        }

            // GET: Libraries/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: Libraries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Publisher,Price,Isbn")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Libraries.Add(library);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(library);
        }

        // GET: Libraries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Publisher,Price,Isbn")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(library);
        }

        // GET: Libraries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Library library = db.Libraries.Find(id);
            db.Libraries.Remove(library);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
