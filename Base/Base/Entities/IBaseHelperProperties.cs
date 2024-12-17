using System.ComponentModel.DataAnnotations.Schema;
using Base;

namespace AccountingSystem;

public interface IBaseHelperProperties<TEntity> where TEntity : BaseEntity
{
    [NotMapped]
    public Func<TEntity , bool>? QueryExpression { get; set; }
}
