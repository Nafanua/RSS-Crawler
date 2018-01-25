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
        string concatString;
        int AddedNewsCounter;

        public Data_Contract()
        {
            context = new ModelContext();
            coincidence = false;
            logger = LogManager.GetCurrentClassLogger();
            AddedNewsCounter = 0;
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

                if (itemDbo.Guid != null)
                {
                    concatString = itemDbo.Guid + extractedData.Channel.Link;
                }
                else
                {
                    concatString = itemDbo.Title + extractedData.Channel.Link;
                }                

                int hashId = concatString.GetHashCode();

                itemDbo.HashId = hashId;

                coincidence = context.Items.Any(i => i.HashId.Equals(itemDbo.HashId));
                
                if (!coincidence)
                {
                    context.Items.Add(itemDbo);
                    AddedNewsCounter++;
                }                
            }

            logger.Trace("Start writing in Db");

            try
            {
                context.SaveChanges();
                logger.Trace("Was added {0} news", AddedNewsCounter);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);              
            }            
        }
    }
}
