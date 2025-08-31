using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.ADONET
{
    public class AdoCategory : ICategoryDAL
    {
        public bool Add(Category entity)
        {
            using(SqlConnection sqlConnection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string sql = @"INSERT INTO Category(CreatedTime,UpdatedTime,Active,CategoryName,CategoryDescription)values(@createdTime,@updatedTime,@active,@categoryName,@description)";
                    command.CommandText = sql;
                    command.Connection = sqlConnection;

                    command.Parameters.AddWithValue("@createdTime", entity.CreatedTime);

                    command.Parameters.AddWithValue("@updatedTime", entity.UpdatedTime);

                    command.Parameters.AddWithValue("@active", entity.Active);

                    command.Parameters.AddWithValue("@categoryName", entity.CategoryName);

                    command.Parameters.AddWithValue("@description", entity.CategoryDescription);

                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();


                    if(command.ExecuteNonQuery() > 0)
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
        }

        public bool Delete(Category entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string sql = @"UPDATE Category SET UpdatedTime=@updatedTime, Active=@active WHERE Id = @id";
                    command.CommandText = sql;
                    command.Connection = sqlConnection;

                    command.Parameters.AddWithValue("@updatedTime", DateTime.Now);

                    command.Parameters.AddWithValue("@active", false);

                    command.Parameters.AddWithValue("@id", entity.Id);

                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();


                    if (command.ExecuteNonQuery() > 0)
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

        }
 
        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string sql = @"SELECT c.* ";


                    if (includes.Contains("ProductCategories") && includes.Contains("Products"))                  
                        sql += ",p.Id, p.ProductName, p.ProductDescription, p.Stock, p.Price ";
                    if (includes.Contains("ProductMedias") && includes.Contains("Medias"))
                        sql += ", m.Path, m.Size, m.MediaTypeId";

                    sql += "FROM Category c";

                    if (includes.Contains("ProductCategories") && includes.Contains("Products"))
                        sql += "JOİN ProductCategories pc ON pc.CategoryId = c.Id JOİN Products p on pc.ProductId = p.Id";

                    if (includes.Contains("ProductMedias") && includes.Contains("Medias"))
                        sql += "JOİN ProductMedias pm on p.Id = pm.ProductId JOİN Medias m on pm.MediaId = m.Id";

                    sql += "WHERE 1=1";

                    if (expression.Body is BinaryExpression binaryExpression)
                    {
                        if(binaryExpression.Left is MemberExpression left && left.Member.Name =="Active" && binaryExpression.NodeType == ExpressionType.Equal)
                        {
                            var value = ((ConstantExpression)(binaryExpression.Right)).Value;

                            sql += " AND Active ==@active";
                            command.Parameters.AddWithValue("@active", value);
                        }

                        if(binaryExpression.Left is MemberExpression left2 && left2.Member.Name == "CategoryName" && binaryExpression.NodeType == ExpressionType.Equal)
                        {
                            var value = ((ConstantExpression)(binaryExpression.Right)).Value;

                            sql += " AND CategoryName LIKE @categoryName";
                            command.Parameters.AddWithValue("@categoryName", "%"+ value + "%");
                        }

                        if (binaryExpression.Left is MemberExpression left3 && left3.Member.Name == "CategoryDescription" && binaryExpression.NodeType == ExpressionType.Equal)
                        {
                            var value = ((ConstantExpression)(binaryExpression.Right)).Value;

                            sql += " AND CategoryDescription LIKE @categoryDescription";
                            command.Parameters.AddWithValue("@categoryDescription", "%" + value + "%");
                        }


                    }

                    if (sortable == Sortable.ASC)
                        sql += "ORDER BY c.Id";
                    else
                        sql += "ORDER BY c.Id DESC";

                    command.CommandText = sql;
                    command.Connection = sqlConnection;
                    

                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();


                    var result = command.ExecuteReader();

                    List<Category> categories = new List<Category>();
                    while (result.Read())
                    {
 
                        categories.Add(new Category { Id = result.GetInt32(0), CategoryName = result.GetString(1), CategoryDescription = result.GetString(2), CreatedTime = result.GetDateTime(3), UpdatedTime = result.GetDateTime(4), Active = result.GetBoolean(5) });
                    }                 
                    
                    if (sqlConnection.State == System.Data.ConnectionState.Open)
                        sqlConnection.Close();

                    return categories;
 
                }
            }
        }

        public Category GetById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string sql = @"SELECT * FROM Category WHERE Id = @id AND Active=@active";
                    command.CommandText = sql;
                    command.Connection = sqlConnection;

                    command.Parameters.AddWithValue("@active", true);

                    command.Parameters.AddWithValue("@id", id);

                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();

                  
                    var result = command.ExecuteReader();                     

                    if (result.Read())
                    {
                        SqlDataReader data = result;

                        if (sqlConnection.State == System.Data.ConnectionState.Open)
                            sqlConnection.Close();


                        return new Category { Id = result.GetInt32(0), CategoryName = data.GetString(1), CategoryDescription = data.GetString(2), CreatedTime =data.GetDateTime(3), UpdatedTime=data.GetDateTime(4), Active=data.GetBoolean(5)  };
                    }
                    else
                    {
                        if (sqlConnection.State == System.Data.ConnectionState.Open)
                            sqlConnection.Close();
                          
                        return null;
                    }                       
                }
            }
        }

        public bool Update(Category entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string sql = @"UPDATE Category SET UpdatedTime=@updatedTime, CategoryName=@categoryName, CategoryDescription=@description WHERE Id = @id";
                    command.CommandText = sql;
                    command.Connection = sqlConnection;                    

                    command.Parameters.AddWithValue("@updatedTime", DateTime.Now);

                    command.Parameters.AddWithValue("@categoryName", entity.CategoryName);

                    command.Parameters.AddWithValue("@description", entity.CategoryDescription);

                    command.Parameters.AddWithValue("@id", entity.Id);

                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();


                    if (command.ExecuteNonQuery() > 0)
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
        }

		public bool Updatecategory(Category entity)
		{
			throw new NotImplementedException();
		}
	}
}
