using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AlisverisLab.DataAccess.Concrete.Dapper
{
    public class DapperCategory : ICategoryDAL
    {
        public bool Add(Category entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                 
                    string sql = @"INSERT INTO Category(CreatedTime,UpdatedTime,Active,CategoryName,CategoryDescription)values(@CreatedTime,@UpdatedTime,@Active,@CategoryName,@CategoryDescription)";
                    

                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();


                    if (sqlConnection.Execute(sql,entity) > 0)
                    {
                        if (sqlConnection.State == System.Data.ConnectionState.Open)
                            sqlConnection.Close();

                        return true;
                    }
                    else
                    {
                        if (sqlConnection.State == System.Data.ConnectionState.Open)
                            sqlConnection.Close();

                        return false;
                    }               
            }
        }

        public bool Delete(Category entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {

                string sql = @"UPDATE Category SET UpdatedTime=@updatedTime, Active= '0' WHERE Id = @Id";


                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();


                if (sqlConnection.Execute(sql, entity) > 0)
                {
                    if (sqlConnection.State == System.Data.ConnectionState.Open)
                        sqlConnection.Close();

                    return true;
                }
                else
                {
                    if (sqlConnection.State == System.Data.ConnectionState.Open)
                        sqlConnection.Close();

                    return false;
                }
            }
        }
 
        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                
                var queryBuilder = new StringBuilder($"SELECT * FROM {typeof(Category).Name} c");

                if(includes != null && includes.Length > 0)
                {
                    string beforeTable = "";
                    for (int i=0; i<includes.Length; i++)
                    {
                        if (i == 0)                       
                            queryBuilder.Append($" LEFT JOIN {includes[i]} ON {includes[i].Substring(0, includes[i].Length - 1)}Id = c.Id");
                        else
                        {
                            beforeTable = includes[i];
                            queryBuilder.Append($" LEFT JOIN {includes[i]} ON {includes[i].Substring(0, includes[i].Length - 1)}Id ={beforeTable}.Id");
                        }
                                                    
                    }
                }

                if (expression != null)
                {
                    string whereExpression = GetWhereExpression(expression);

                    queryBuilder.Append($" WHERE {whereExpression}");
                }

                if (sortable == Sortable.ASC)
                    queryBuilder.Append("ORDER BY Id");
                else
                    queryBuilder.Append("ORDER BY Id DESC");

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();


                List<Category> result = sqlConnection.Query<Category>(queryBuilder.ToString()).ToList();

                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();

                return result;
            }
        }
        private string GetWhereExpression<T>(Expression<Func<T,bool>> expression)
        {

            if (expression.Body is BinaryExpression binary)
            {
                if (binary.NodeType == ExpressionType.Equal)
                {
                    var left = binary.Left.ToString();
                    var right = binary.Right.ToString();

                    return $"{left} = {right}";
                }
                else if (binary.NodeType == ExpressionType.NotEqual)
                {
                    var left = binary.Left.ToString();
                    var right = binary.Right.ToString();

                    return $"{left} != {right}";
                }
                else if (binary.NodeType == ExpressionType.GreaterThanOrEqual)
                {
                    var left = binary.Left.ToString();
                    var right = binary.Right.ToString();

                    return $"{left} >= {right}";
                }
                else if (binary.NodeType == ExpressionType.GreaterThan)
                {
                    var left = binary.Left.ToString();
                    var right = binary.Right.ToString();

                    return $"{left} > {right}";
                }
                else if (binary.NodeType == ExpressionType.LessThanOrEqual)
                {
                    var left = binary.Left.ToString();
                    var right = binary.Right.ToString();

                    return $"{left} <= {right}";
                }
                else if (binary.NodeType == ExpressionType.LessThan)
                {
                    var left = binary.Left.ToString();
                    var right = binary.Right.ToString();

                    return $"{left} < {right}";
                }
                else return "";
            }
            else return "";
        }


        public Category GetById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {

                string sql = @"SELECT * FROM Categories WHERE Active='1' AND Id =@id";


                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();


                Category result = sqlConnection.QueryFirstOrDefault<Category>(sql, id);  

                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();

                return result;
            }
        }

        public bool Update(Category entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {

                string sql = @"UPDATE Category SET UpdatedTime=@UpdatedTime, CategoryName=@CategoryName, CategoryDescription=@CategoryDescription WHERE Id = @Id";


                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();


                if (sqlConnection.Execute(sql, entity) > 0)
                {
                    if (sqlConnection.State == System.Data.ConnectionState.Open)
                        sqlConnection.Close();

                    return true;
                }
                else
                {
                    if (sqlConnection.State == System.Data.ConnectionState.Open)
                        sqlConnection.Close();

                    return false;
                }
            }
        }

		public bool Updatecategory(Category entity)
		{
			throw new NotImplementedException();
		}
	}
}
