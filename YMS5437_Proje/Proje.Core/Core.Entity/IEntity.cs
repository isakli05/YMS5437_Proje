namespace Proje.Core.Core.Entity
{
    //Ortak tip sağlayacak.
    //Her entity'nin ID'ye sahip olması gerektiğini belirtir.
    //Hatırlarsanız interface bir sözleşmedir ve yetenek kazandırma amacıyla yazılır demiştik.
    
    public interface IEntity<T> //T herhangi bir type anlamına gelir.
    {
        T ID { get; set; }
    }
}
