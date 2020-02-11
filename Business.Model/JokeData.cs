using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using SqlSugar;

namespace Business.Model
{
    [SugarTable("T_JokeClient_Data")]//对应数据库的T_JokeClient_Data表
    [DataContract]
    [Serializable]
    public class JokeData
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        /// <summary>
        ///编号
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        ///标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        ///内容
        /// </summary>
        [DataMember]
        public string Contents { get; set; }

        /// <summary>
        ///点赞数
        /// </summary>
        [DataMember]
        public long ZanCount { get; set; }

        /// <summary>
        ///不赞数
        /// </summary>
        [DataMember]
        public long PointsCount { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [DataMember]
        public int CreateBy { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///更新人
        /// </summary>
        [DataMember]
        public int UpdateBy { get; set; }

        /// <summary>
        ///更新时间
        /// </summary>
        [DataMember]
        public DateTime UpdateDate { get; set; }
    }
}
