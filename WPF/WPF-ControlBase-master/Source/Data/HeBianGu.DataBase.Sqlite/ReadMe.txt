���ݿ�Ǩ������
����һ��������´��룬�������ʱ DbContext ����
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlite("Data Source=Migration.db");

            return new DataContext(optionsBuilder.Options);
        }
    }
���������֤��������������ɳɹ�

��������DbContext������ڵ�ǰ��������

�����������������
HeBianGu.DataBase.Sqlite

��������ִ��Ǩ���������Ǩ���ļ�
add-migration init -project HeBianGu.DataBase.Sqlite

�����ģ�ִ�и������ݿ����ͬ�������ݿ���
Update-Database -project HeBianGu.DataBase.Sqlite

���������Զ�ִ��Ǩ�ƣ��滻�������ݿⷽ��
db.Database.Migrate();�滻�� db.Database.EnsureCreated();


