using CardOrg.Entities;
using CardOrg.Interfaces.Factories;
using CardOrg.Interfaces.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Repositories
{
    public class SearchSortRepository : ISearchSortRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public SearchSortRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<SearchSortEntity>> GetSearchSortAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.SearchSort ORDER BY Name ASC";

            var parameters = new DynamicParameters();

            CommandDefinition commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<SearchSortEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        public async Task<SearchSortEntity> InsertSearchSortAsync(SearchSortEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Cards 
                            ([Name]
                            ,[Description]
                            ,[IsGraded]
                            ,[IsRookie]
                            ,[IsAutograph]
                            ,[IsPatch]
                            ,[IsOnCardAutograph]
                            ,[IsGameWornJersey]
                            ,[PlayerIds]
                            ,[TeamIds]
                            ,[SportIds]
                            ,[YearIds]
                            ,[SetIds]
                            ,[GradeCompanyIds]
                            ,[LocationIds]
                            ,[CardDescription]
                            ,[LowestBecketPriceLow]
                            ,[LowestBecketPriceHigh]
                            ,[HighestBecketPriceLow]
                            ,[HighestBecketPriceHigh]
                            ,[LowestCOMCPriceLow]
                            ,[LowestCOMCPriceHigh]
                            ,[EbayPriceLow]
                            ,[EbayPriceHigh]
                            ,[PricePaidLow]
                            ,[PricePaidHigh]
                            ,[GradeLow]
                            ,[GradeHigh]
                            ,[CopiesLow]
                            ,[CopiesHigh]
                            ,[SerialNumberLow]
                            ,[SerialNumberHigh]
                            ,[HasImage]
                            ,[TimeStampStart]
                            ,[TimeStampEnd]
                            ,[PlayerNameSort]
                            ,[TeamSort]
                            ,[CardDescriptionSort]
                            ,[LowestBeckettPriceSort]
                            ,[HighestBeckettPriceSort]
                            ,[LowestCOMCPriceSort]
                            ,[EbayPriceSort]
                            ,[PricePaidSort]
                            ,[HasImageSort]
                            ,[IsGradedSort]
                            ,[CopiesSort]
                            ,[SerialNumberSort]
                            ,[GradeSort]
                            ,[IsRookieSort]
                            ,[IsAutographSort]
                            ,[IsPatchSort]
                            ,[IsOnCardAutographSort]
                            ,[IsGameWornJerseySort]
                            ,[SportSort]
                            ,[YearSort]
                            ,[SetSort]
                            ,[GradeCompanySort]
                            ,[LocationSort]
                            ,[TimeStampSort]
                            ,[TimeStamp]
                        )
                        VALUES (@Name
                            ,@Description
                            ,@IsGraded
                            ,@IsRookie
                            ,@IsAutograph
                            ,@IsPatch
                            ,@IsOnCardAutograph
                            ,@IsGameWornJersey
                            ,@PlayerIds
                            ,@TeamIds
                            ,@SportIds
                            ,@YearIds
                            ,@SetIds
                            ,@GradeCompanyIds
                            ,@LocationIds
                            ,@CardDescription
                            ,@LowestBecketPriceLow
                            ,@LowestBecketPriceHigh
                            ,@HighestBecketPriceLow
                            ,@HighestBecketPriceHigh
                            ,@LowestCOMCPriceLow
                            ,@LowestCOMCPriceHigh
                            ,@EbayPriceLow
                            ,@EbayPriceHigh
                            ,@PricePaidLow
                            ,@PricePaidHigh
                            ,@GradeLow
                            ,@GradeHigh
                            ,@CopiesLow
                            ,@CopiesHigh
                            ,@SerialNumberLow
                            ,@SerialNumberHigh
                            ,@HasImage
                            ,@TimeStampStart
                            ,@TimeStampEnd
                            ,@PlayerNameSort
                            ,@TeamSort
                            ,@CardDescriptionSort
                            ,@LowestBeckettPriceSort
                            ,@HighestBeckettPriceSort
                            ,@LowestCOMCPriceSort
                            ,@EbayPriceSort
                            ,@PricePaidSort
                            ,@HasImageSort
                            ,@IsGradedSort
                            ,@CopiesSort
                            ,@SerialNumberSort
                            ,@GradeSort
                            ,@IsRookieSort
                            ,@IsAutographSort
                            ,@IsPatchSort
                            ,@IsOnCardAutographSort
                            ,@IsGameWornJerseySort
                            ,@SportSort
                            ,@YearSort
                            ,@SetSort
                            ,@GradeCompanySort
                            ,@LocationSort
                            ,@TimeStampSort
                            ,@TimeStamp
                            ,@TimeStamp
                        ) 
                        SELECT SCOPE_IDENTITY()";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", entity.Name);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@IsGraded", entity.IsGraded);
            parameters.Add("@IsRookie", entity.IsRookie);
            parameters.Add("@IsAutograph", entity.IsAutograph);
            parameters.Add("@IsPatch", entity.IsPatch);
            parameters.Add("@IsOnCardAutograph", entity.IsOnCardAutograph);
            parameters.Add("@IsGameWornJersey", entity.IsGameWornJersey);
            parameters.Add("@PlayerIds", entity.PlayerIds);
            parameters.Add("@TeamIds", entity.TeamIds);
            parameters.Add("@SportIds", entity.SportIds);
            parameters.Add("@YearIds", entity.YearIds);
            parameters.Add("@SetIds", entity.SetIds);
            parameters.Add("@GradeCompanyIds", entity.GradeCompanyIds);
            parameters.Add("@LocationIds", entity.LocationIds);
            parameters.Add("@CardDescription", entity.CardDescription);
            parameters.Add("@LowestBecketPriceLow", entity.LowestBecketPriceLow);
            parameters.Add("@LowestBecketPriceHigh", entity.LowestBecketPriceHigh);
            parameters.Add("@HighestBecketPriceLow", entity.HighestBecketPriceLow);
            parameters.Add("@HighestBecketPriceHigh", entity.HighestBecketPriceHigh);
            parameters.Add("@LowestCOMCPriceLow", entity.LowestCOMCPriceLow);
            parameters.Add("@LowestCOMCPriceHigh", entity.LowestCOMCPriceHigh);
            parameters.Add("@EbayPriceLow", entity.EbayPriceLow);
            parameters.Add("@EbayPriceHigh", entity.EbayPriceHigh);
            parameters.Add("@PricePaidLow", entity.PricePaidLow);
            parameters.Add("@PricePaidHigh", entity.PricePaidHigh);
            parameters.Add("@GradeLow", entity.GradeLow);
            parameters.Add("@GradeHigh", entity.GradeHigh);
            parameters.Add("@CopiesLow", entity.CopiesLow);
            parameters.Add("@CopiesHigh", entity.CopiesHigh);
            parameters.Add("@SerialNumberLow", entity.SerialNumberLow);
            parameters.Add("@SerialNumberHigh", entity.SerialNumberHigh);
            parameters.Add("@HasImage", entity.HasImage);
            parameters.Add("@TimeStampStart", entity.TimeStampStart);
            parameters.Add("@TimeStampEnd", entity.TimeStampEnd);
            parameters.Add("@PlayerNameSort", entity.PlayerNameSort);
            parameters.Add("@TeamSort", entity.TeamSort);
            parameters.Add("@CardDescriptionSort", entity.CardDescriptionSort);
            parameters.Add("@LowestBeckettPriceSort", entity.LowestBeckettPriceSort);
            parameters.Add("@HighestBeckettPriceSort", entity.HighestBeckettPriceSort);
            parameters.Add("@LowestCOMCPriceSort", entity.LowestCOMCPriceSort);
            parameters.Add("@EbayPriceSort", entity.EbayPriceSort);
            parameters.Add("@PricePaidSort", entity.PricePaidSort);
            parameters.Add("@HasImageSort", entity.HasImageSort);
            parameters.Add("@IsGradedSort", entity.IsGradedSort);
            parameters.Add("@CopiesSort", entity.CopiesSort);
            parameters.Add("@SerialNumberSort", entity.SerialNumberSort);
            parameters.Add("@GradeSort", entity.GradeSort);
            parameters.Add("@IsRookieSort", entity.IsRookieSort);
            parameters.Add("@IsAutographSort", entity.IsAutographSort);
            parameters.Add("@IsPatchSort", entity.IsPatchSort);
            parameters.Add("@IsOnCardAutographSort", entity.IsOnCardAutographSort);
            parameters.Add("@IsGameWornJerseySort", entity.IsGameWornJerseySort);
            parameters.Add("@SportSort", entity.SportSort);
            parameters.Add("@YearSort", entity.YearSort);
            parameters.Add("@SetSort", entity.SetSort);
            parameters.Add("@GradeCompanySort", entity.GradeCompanySort);
            parameters.Add("@LocationSort", entity.LocationSort);
            parameters.Add("@TimeStampSort", entity.TimeStampSort);
            parameters.Add("@TimeStamp", DateTime.Now);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                entity.SearchSortId = await connection.ExecuteScalarAsync<int>(commandDefinition).ConfigureAwait(false);
                return entity;
            }
        }
    }
}
