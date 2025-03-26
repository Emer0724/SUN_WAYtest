public IEnumerable<object> GetDepartments(string? departmentId = null, string? userId = null)
{
    string connectionString = "connectionString";
    using (var cn = new SqliteConnection(connectionString))
    {
        cn.Open();
        string sql = "SELECT DepartmentId, UserId, UserName FROM Departments";

        List<string> strings = new List<string>();
        var parameters = new List<SqliteParameter>();

        if (!string.IsNullOrEmpty(departmentId))
        {
            strings.Add("DepartmentId = @DepartmentId");
            parameters.Add(new SqliteParameter("@DepartmentId", departmentId));
        }

        if (!string.IsNullOrEmpty(userId))
        {
            strings.Add("UserId = @UserId");
            parameters.Add(new SqliteParameter("@UserId", userId));
        }

        if (strings.Count > 0)
        {
            sql += " WHERE " + string.Join(" AND ", strings);
        }

        using (var cmd = new SqliteCommand(sql, cn))
        {
            foreach (var param in parameters)
            {
                cmd.Parameters.Add(param);
            }

            using (var dr = cmd.ExecuteReader())
            {
                var result = new List<object>();
                while (dr.Read())
                {
                    result.Add(new
                    {
                        DepartmentId = dr["DepartmentId"],
                        UserId = dr["UserId"],
                        UserName = dr["UserName"]
                    });
                }
                return result; // 讀取完後一次性回傳
            }
        }
    }
}
