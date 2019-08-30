using Xendor.Data;

namespace Xendor.CommandModel.MySql
{
    internal class MySqlEventCreateCollectionQuery : Query
    {
        public MySqlEventCreateCollectionQuery(string collectionName)
        {
            CollectionName = collectionName;
        }
        public string CollectionName { get; }
        public override string Sql => $"CREATE TABLE  IF NOT EXISTS `{CollectionName}_event` " +
                                      $"(`Id` int(11) NOT NULL AUTO_INCREMENT," +
                                      $"`AggregateId` char(36) NOT NULL," +
                                      $"`Version` int(255) NOT NULL," +
                                      $"`TimeStamp` double NOT NULL," +
                                      $"`Payload` json NOT NULL," +
                                      $"`ContentType` varchar(255) NOT NULL, " +
                                      $"PRIMARY KEY (`Id`)) " +
                                      $"ENGINE = InnoDB DEFAULT CHARSET = latin1; SET FOREIGN_KEY_CHECKS=1;";
    }
}