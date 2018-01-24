using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using CodeFirst;
using RSS_Crawler.XML_Classes;

namespace DataContract
{
    class Data_Contract
    {
        private List<RssChannelItemDbo> DbItems;

        public Data_Contract()
        {
            DbItems = new List<RssChannelItemDbo>();
        }

        public void MapperStart(Rss extractedData)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RssChannelItem, RssChannelItemDbo>());

            DbItems = Mapper.Map<IEnumerable<RssChannelItem>, List<RssChannelItemDbo>>(extractedData.Channel.Item);
        }
    }
}
