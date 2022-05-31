using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineBankDemo.DataAccessLayer.Common
{
    public interface IReadOnlyGenericRepository<T> where T : class
    {
        /// <summary>
        /// Возвращает запрос на получения всех данных из указанного типа
        /// </summary>
        IQueryable<T> GetAll();

        /// <summary>
        /// Формирование запроса с указанием условия для фильтрации данных
        /// </summary>
        /// <param name="predicate">Условие для фильтрации</param>
        /// <seealso cref="Queryable.Where{TSource}(IQueryable{TSource},Expression)"/>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Поиск определенной записи по ключу(-ам)
        /// </summary>
        /// <param name="keyValues">Первичный ключ(-и)</param>
        T FindByKey(params object[] keyValues);

        /// <summary>
        /// Возвращает первую запись из базы данных по указанному условию, если такая есть, иначе значение по умолчанию
        /// </summary>
        /// <param name="predicate">Условие поиска</param>
        /// <seealso cref="Queryable.FirstOrDefault{TSource}(IQueryable{TSource})"/>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Возвращает первую запись из базы данных по указанному условию, если такая есть,
        /// иначе выбрасывает исключение
        /// </summary>
        /// <param name="predicate">Условие поиска</param>
        /// <param name="ifNullErrorMessage">Текст сообщения об ошибке в случае, если запись по указанному условию не найдена</param>
        /// <seealso cref="Queryable.FirstOrDefault{TSource}(IQueryable{TSource})"/>
        T GetFirst(Expression<Func<T, bool>> predicate, string ifNullErrorMessage = "");

        DbContext Context { get; }
    }
    
    public interface IGenericRepository<T>: IReadOnlyGenericRepository<T> where T : class
    {
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        T Edit(T entity);
        void EditRange(IEnumerable<T> entities);
        T Attach(T entity);
        void Save();

        /// <summary>
        /// Открепить локальные сущности (в указанном состоянии) от контекста (перестать отслеживать)
        /// </summary>
        /// <param name="state">Состояние сущности, при котором её нужно открепить. null - любое состояние (можно использовать флаги)</param>
        void DetachAll(EntityState? state = null);
    }
}