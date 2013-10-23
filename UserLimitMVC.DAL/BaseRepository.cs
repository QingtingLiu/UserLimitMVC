using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UserLimitMVC.Model;
using System.Data.Entity;

namespace UserLimitMVC.DAL
{
    /// <summary>
    /// 实现对数据库的操作（增删改查）的基类
    /// </summary>
    /// <typeparam name="T">类</typeparam>
    public class BaseRepository<T> where T : class
    {
        //EF框架的上下文
        private DataModelContainer db = new DataModelContainer();
        //实现对数据库的添加功能
        public T AddEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Added;
            db.SaveChanges();
            return entity;
        }
        //实现对数据库的修改功能
        public bool UpdateEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        //实现对数据库的删除功能
        public bool DeleteEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }
        //实现对数据库的简单查询功能
        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda).AsQueryable();
        }

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条的数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">排序条件</param>
        /// <param name="isAsc">升序？降序？</param>
        /// <param name="orderByLambda">根据那个字段排序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out  int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            //按排序条件找出数据
            var temp = db.Set<T>().Where<T>(whereLambda);
            total = temp.Count(); //总行数
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            return temp.AsQueryable();
        }
    }
}
