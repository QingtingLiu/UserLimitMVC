using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLimitMVC.IDAL
{
    public interface IBaseRepository<T> where T : class ,new()
    {
        // 实现对数据库的添加功能,添加实现EF框架的引用
        T AddEntity(T entity);
        //实现对数据库的修改功能
        bool UpdateEntity(T entity);
        ////实现对数据库的删除功能
        bool DeleteEntity(T entity);
        //实现对数据库的简单查询功能
        IQueryable<T> LoadEntities(Func<T, bool> whereLambda);
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">每页显示多少行</param>
        /// <param name="total">总行数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="isAsc">升序？降序？</param>
        /// <param name="orderByLambda">根据那个字段进行排序</param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda);
    }
}
