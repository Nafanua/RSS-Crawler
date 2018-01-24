using AutoMapper;
using RSS_Crawler.XML_Classes;
using DAL;
using RSS_Crawler.Interfases;
using NLog;
using System;
using System.Linq;

namespace DataContract
{
    public class Data_Contract : IData_Contract
    {
        private ModelContext context;
        private bool coincidence;
        private Logger logger;

        public Data_Contract()
        {
            context = new ModelContext();
            coincidence = false;
            logger = LogManager.GetCurrentClassLogger();
        }

        public void MapperStart(Rss extractedData)
        {
            logger.Trace("Start Mapping");

            Mapper.Initialize(cfg => {
                cfg.CreateMap<RssChannelItem, RssChannelItemDbo>()
                .ForMember("CategoryUrl", x => x.MapFrom(c => c.Category.Domain))
                .ForMember("SourceUrl", x => x.MapFrom(c => c.Source.Url))
                .ForMember("EnclosureUrl", x => x.MapFrom(c => c.Enclosure.Url));
                });
           
            foreach (var item in extractedData.Channel.Item)
            {
                var itemDbo = Mapper.Map<RssChannelItem, RssChannelItemDbo>(item);

                string concatString = itemDbo.Title + itemDbo.Link;

                int hashId = concatString.GetHashCode();

                itemDbo.HashId = hashId;

                coincidence = context.Items.Any(i => i.HashId.Equals(itemDbo.HashId));
                
                if (!coincidence)
                {
                    context.Items.Add(itemDbo);
                }                
            }

            logger.Trace("Start writing in Db");

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);              
            }            
        }
    }
}
