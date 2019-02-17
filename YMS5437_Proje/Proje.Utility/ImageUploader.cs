using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Proje.Utility
{
    public class ImageUploader
    {
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                //Eğer dosya boş değilse, kullanıcının gödnerdiği dosyanın adını değiştirmek için(kendi kalsör yolu ile birlikte gelecektir. O şekilde kaydetmek istemeyiz.) altta değişken oluşturuyoruz.

                var uniqueName = Guid.NewGuid();
                //Server yolunda ~ işaretleri kalmasın diye onları yok ediyoruz.
                serverPath = serverPath.Replace("~", string.Empty);

                string[] fileArray = file.FileName.Split('.');

                //Dosyanın uzantısı yakalıyoruz.
                string extension = fileArray[fileArray.Length - 1].ToLower();

                //Bize gönderilen dosyanın ismini değiştirip uzantısını sakladık ki çalışmaya devam etsin. Tİpini bozmayalım.
                string fileName = uniqueName + "." + extension;

                //Uzantı kontrolü => Eğer kabul ettiğimiz uzantılardan birinde değilse hata kodu gönder.

                if (extension == "jpg" || extension == "png" || extension == "jpeg" || extension == "gif")
                {
                    //Eğer zaten böyle bir dosya varsa(Belirtilen yolda, belirtilen isimde bir dosya varsa)
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        //Dosya zaten var hatası kodu 1.
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        //Eğer dosya yoksa ve uzantı da uyuyorsa, o zaman dosyayı parametrede belirttiğim klasöre kaydet ve geriye yolunu string tipte döndür. Bu sayede veritabanında biz image yolunu tutabilelim.
                        return serverPath + fileName;
                    }
                }
                else
                {
                    //Dosya uzantısı Hatası kodu 2 oldu.
                    return "2";
                }

            }
            else
            {
                //Dosya NUll hatası kodu 0.
                return "0";
            }
        }
    }
}
