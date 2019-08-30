

using Xendor.Data;

namespace Xendor.CommandModel.MySql.SnapShotting
{
    internal class MySqlSnapshotCreateCollectionQuery : Query
    {
        public MySqlSnapshotCreateCollectionQuery(string collectionName)
            :base()
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }


        public override string Sql => $"CREATE TABLE IF NOT EXISTS `{CollectionName}_snapshot` (`MessageId` int(11) NOT NULL AUTO_INCREMENT,`AggregateId` char(36) NOT NULL,`Version` int(255) NOT NULL,`Payload` json NOT NULL,`ContentType` varchar(255) NOT NULL,PRIMARY KEY(`MessageId`)) ENGINE = InnoDB DEFAULT CHARSET = latin1;SET FOREIGN_KEY_CHECKS = 1;";
    }
}