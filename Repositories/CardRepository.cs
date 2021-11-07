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
    /// <summary>
    /// The card repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.ICardRepository" />
    public class CardRepository : ICardRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CardRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public CardRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CardEntity>> GetCardsAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.Cards ORDER BY HighestBeckettPrice DESC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<CardEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> InsertCardAsync(CardEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Cards 
                            ([CardDescription], 
                            [CardNumber],
                            [LowestBeckettPrice],
                            [HighestBeckettPrice],
                            [FrontCardMainImagePath],
                            [FrontCardThumbnailImagePath],
                            [BackCardMainImagePath],
                            [BackCardThumbnailImagePath],
                            [LowestCOMCPrice],
                            [EbayPrice],                           
                            [PricePaid], 
                            [IsGraded],
                            [Copies],
                            [SerialNumber],
                            [Grade],
                            [IsRookie],
                            [IsAutograph],
                            [IsPatch],
                            [IsOnCardAutograph],
                            [IsGameWornJersey],
                            [SportId],
                            [YearId],
                            [SetId],
                            [GradeCompanyId],
                            [LocationId],
                            [TimeStamp]
                        )
                        VALUES (@CardDescription, 
                            @CardNumber,
                            @LowestBeckettPrice,
                            @HighestBeckettPrice,
                            @FrontCardMainImagePath,
                            @FrontCardThumbnailImagePath,
                            @BackCardMainImagePath,
                            @BackCardThumbnailImagePath,
                            @LowestCOMCPrice,
                            @EbayPrice,                           
                            @PricePaid, 
                            @IsGraded,
                            @Copies,
                            @SerialNumber,
                            @Grade,
                            @IsRookie,
                            @IsAutograph,
                            @IsPatch,
                            @IsOnCardAutograph,
                            @IsGameWornJersey,
                            @SportId,
                            @YearId,
                            @SetId,
                            @GradeCompanyId,
                            @LocationId,
                            @TimeStamp
                        ) ";

            var parameters = new DynamicParameters();
            parameters.Add("@CardDescription", entity.CardDescription);
            parameters.Add("@CardNumber", entity.CardNumber);
            parameters.Add("@LowestBeckettPrice", entity.LowestBeckettPrice);
            parameters.Add("@HighestBeckettPrice", entity.HighestBeckettPrice);
            parameters.Add("@FrontCardMainImagePath", entity.FrontCardMainImagePath);
            parameters.Add("@FrontCardThumbnailImagePath", entity.FrontCardThumbnailImagePath);
            parameters.Add("@BackCardMainImagePath", entity.BackCardMainImagePath);
            parameters.Add("@BackCardThumbnailImagePath", entity.BackCardThumbnailImagePath);
            parameters.Add("@LowestCOMCPrice", entity.LowestCOMCPrice);
            parameters.Add("@EbayPrice", entity.EbayPrice);
            parameters.Add("@PricePaid", entity.PricePaid);
            parameters.Add("@IsGraded", entity.IsGraded);
            parameters.Add("@Copies", entity.Copies);
            parameters.Add("@SerialNumber", entity.SerialNumber);
            parameters.Add("@Grade", entity.Grade);
            parameters.Add("@IsRookie", entity.IsRookie);
            parameters.Add("@IsAutograph", entity.IsAutograph);
            parameters.Add("@IsPatch", entity.IsPatch);
            parameters.Add("@IsOnCardAutograph", entity.IsOnCardAutograph);
            parameters.Add("@IsGameWornJersey", entity.IsGameWornJersey);
            parameters.Add("@SportId", entity.SportId);
            parameters.Add("@YearId", entity.YearId);
            parameters.Add("@SetId", entity.SetId);

            if (entity.GradeCompanyId > 0)
            {
                parameters.Add("@GradeCompanyId", entity.GradeCompanyId);
            }
            else
            {
                parameters.Add("@GradeCompanyId", null);
            }

            parameters.Add("@LocationId", entity.LocationId);
            parameters.Add("@TimeStamp", DateTime.Now);
            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> UpdateCardAsync(CardEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.Cards
                            SET CardDescription = @CardDescription, 
                            CardNumber = @CardNumber, 
                            LowestBeckettPrice = @LowestBeckettPrice,
                            HighestBeckettPrice = @HighestBeckettPrice,
                            FrontCardMainImagePath = @FrontCardMainImagePath,
                            FrontCardThumbnailImagePath = @FrontCardThumbnailImagePath,
                            BackCardMainImagePath = @BackCardMainImagePath,
                            BackCardThumbnailImagePath = @BackCardThumbnailImagePath,
                            LowestCOMCPrice = @LowestCOMCPrice,
                            EbayPrice = @EbayPrice,
                            PricePaid = @PricePaid,
                            IsGraded = @IsGraded,
                            Copies = @Copies,
                            SerialNumber = @SerialNumber,
                            Grade = @Grade,
                            IsRookie = @IsRookie,
                            IsAutograph = @IsAutograph,
                            IsPatch = @IsPatch,
                            IsOnCardAutograph = @IsOnCardAutograph,
                            IsGameWornJersey = @IsGameWornJersey,
                            SportId = @SportId,
                            YearId = @YearId,
                            SetId =@SetId,
                            GradeCompanyId = @GradeCompanyId,
                            LocationId = @LocationId,
                            TimeStamp = @TimeStamp
                            WHERE CardId = @CardId
                        )
                        VALUES (@CardDescription, 
                            @CardNumber,
                            @LowestBeckettPrice,
                            @HighestBeckettPrice,
                            @FrontCardMainImagePath,
                            @FrontCardThumbnailImagePath,
                            @BackCardMainImagePath,
                            @BackCardThumbnailImagePath,
                            @LowestCOMCPrice,
                            @EbayPrice,                           
                            @PricePaid, 
                            @IsGraded,
                            @Copies,
                            @SerialNumber,
                            @Grade,
                            @IsRookie,
                            @IsAutograph,
                            @IsPatch,
                            @IsOnCardAutograph,
                            @IsGameWornJersey,
                            @SportId,
                            @YearId,
                            @SetId,
                            @GradeCompanyId,
                            @LocationId,
                            @TimeStamp
                        ) ";

            var parameters = new DynamicParameters();
            parameters.Add("@CardId", entity.CardId);
            parameters.Add("@CardDescription", entity.CardDescription);
            parameters.Add("@CardNumber", entity.CardNumber);
            parameters.Add("@LowestBeckettPrice", entity.LowestBeckettPrice);
            parameters.Add("@HighestBeckettPrice", entity.HighestBeckettPrice);
            parameters.Add("@FrontCardMainImagePath", entity.FrontCardMainImagePath);
            parameters.Add("@FrontCardThumbnailImagePath", entity.FrontCardThumbnailImagePath);
            parameters.Add("@BackCardMainImagePath", entity.BackCardMainImagePath);
            parameters.Add("@BackCardThumbnailImagePath", entity.BackCardThumbnailImagePath);
            parameters.Add("@LowestCOMCPrice", entity.LowestCOMCPrice);
            parameters.Add("@EbayPrice", entity.EbayPrice);
            parameters.Add("@PricePaid", entity.PricePaid);
            parameters.Add("@IsGraded", entity.IsGraded);
            parameters.Add("@Copies", entity.Copies);
            parameters.Add("@SerialNumber", entity.SerialNumber);
            parameters.Add("@Grade", entity.Grade);
            parameters.Add("@IsRookie", entity.IsRookie);
            parameters.Add("@IsAutograph", entity.IsAutograph);
            parameters.Add("@IsPatch", entity.IsPatch);
            parameters.Add("@IsOnCardAutograph", entity.IsOnCardAutograph);
            parameters.Add("@IsGameWornJersey", entity.IsGameWornJersey);
            parameters.Add("@SportId", entity.SportId);
            parameters.Add("@YearId", entity.YearId);
            parameters.Add("@SetId", entity.SetId);

            if (entity.GradeCompanyId > 0)
            {
                parameters.Add("@GradeCompanyId", entity.GradeCompanyId);
            }

            parameters.Add("@LocationId", entity.LocationId);
            parameters.Add("@TimeStamp", DateTime.Now);
            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> DeleteCardAsync(int cardId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.Cards
                        WHERE CardId = @CardId";

            var parameters = new DynamicParameters();
            parameters.Add("@CardId", cardId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }
    }
}
