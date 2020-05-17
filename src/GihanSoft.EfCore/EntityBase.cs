using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GihanSoft.EfCore {
    public interface IEntityBase<TId>
        where TId : struct {
            [UnEncrypted]
            [Key, DatabaseGenerated (DatabaseGeneratedOption.Identity)]
            TId Id { get; set; }
        }

    public interface IEntityBase : IEntityBase<int> { }

    public class EntityBase<TId> : IEntityBase<TId>
        where TId : struct {
            [UnEncrypted]
            [Key, DatabaseGenerated (DatabaseGeneratedOption.Identity)]
            public TId Id { get; set; }
        }

    public class EntityBase : EntityBase<int>, IEntityBase { }
}