���ݿ�Ǩ������
����һ��������´��룬�������ʱ DbContext ����
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-UQVBO72\\SQLEXPRESS; Trusted_Connection=False; uid=sa; pwd=123456;Initial Catalog=PerformanceMigration; MultipleActiveResultSets=true;");

            return new DataContext(optionsBuilder.Options);
        }
    }

���������֤��������������ɳɹ�

��������DbContext������ڵ�ǰ��������

�����������������
HeBianGu.DataBase.SqlServer

��������ִ��Ǩ���������Ǩ���ļ�
add-migration init -project HeBianGu.DataBase.SqlServer

�����ģ�ִ�и������ݿ����ͬ�������ݿ���
Update-Database -project HeBianGu.DataBase.SqlServer

���������Զ�ִ��Ǩ�ƣ��滻�������ݿⷽ��
db.Database.Migrate();�滻�� db.Database.EnsureCreated();


