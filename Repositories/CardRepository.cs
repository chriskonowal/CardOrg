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

        public async Task<int> InsertRecordAsync(CardEntity entity, CancellationToken cancellationToken)
        {
            return 0;
        }

        /// <inheritdoc/>
        //public async Task<int> InsertRecordAsync(CardEntity entity, CancellationToken cancellationToken)
        //{
        //    var sql = @"INSERT INTO dbo.Cards 
        //                    (FirstName, 
        //                    LastName,
        //                    BeginningYear,
        //                    EndingYear,
        //                    CardBrand,
        //                    CardNumber,
        //                    LowestBeckettPrice,
        //                    HighestBeckettPrice,
        //                    FrontCardMainImagePath,
        //                    FrontCardThumbnailImagePath,                           
        //                    BackCardMainImagePath, 
        //              BackCardThumbnailImagePath,
        //              LowestCOMCPrice,
        //              EbayPrice,
        //              PricePaid,
        //              IsGraded,
        //              [Location],
        //              [Copies],
        //              [SerialNumber],
        //              [GradeCompany],
        //              [Grade],
        //              [IsRookie],
        //              [IsAuto],
        //              [IsPatch],
        //              [IsOnCardAuto],
        //              [IsGameWornJersey],
        //                    [SportId]
        //                )
        //                VALUES(@FirstName,
        //                    @LastName,
        //                    @BeginningYear,
        //                    @EndingYear,
        //                    @CardBrand,
        //                    @CardNumber,
        //                    @LowestBeckettPrice,
        //                    @HighestBeckettPrice,
        //                    @FrontCardMainImagePath,
        //                    @FrontCardThumbnailImagePath,
        //                    @BackCardMainImagePath,
        //                    @BackCardThumbnailImagePath,
        //                    @LowestCOMCPrice,
        //                    @EbayPrice,
        //                    @PricePaid,
        //                    @IsGraded,
        //                    @Location,
        //                    @Copies,
        //                    @SerialNumber,
        //                    @GradeCompany,
        //                    @Grade, 
        //                    @IsRookie,
        //                    @IsAuto,
        //                    @IsPatch,
        //                    @IsOnCardAuto,
        //                    @IsGameWornJersey,
        //                    @SportId
        //                ) ";

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@FirstName", entity.FirstName);
        //    parameters.Add("@LastName", entity.LastName);
        //    parameters.Add("@BeginningYear", entity.BeginningYear);
        //    parameters.Add("@EndingYear", entity.EndingYear);
        //    parameters.Add("@CardBrand", entity.CardBrand);
        //    parameters.Add("@CardNumber", entity.CardNumber);
        //    parameters.Add("@LowestBeckettPrice", entity.LowestBeckettPrice);
        //    parameters.Add("@HighestBeckettPrice", entity.HighestBeckettPrice);
        //    parameters.Add("@FrontCardMainImagePath", entity.FrontCardMainImagePath);
        //    parameters.Add("@FrontCardThumbnailImagePath", entity.FrontCardThumbnailImagePath);
        //    parameters.Add("@BackCardMainImagePath", entity.BackCardMainImagePath);
        //    parameters.Add("@BackCardThumbnailImagePath", entity.BackCardThumbnailImagePath);
        //    parameters.Add("@LowestCOMCPrice", entity.LowestCOMCPrice);
        //    parameters.Add("@EbayPrice", entity.EbayPrice);
        //    parameters.Add("@PricePaid", entity.PricePaid);
        //    parameters.Add("@IsGraded", entity.IsGraded);
        //    parameters.Add("@Location", entity.Location);
        //    parameters.Add("@Copies", entity.Copies);
        //    parameters.Add("@SerialNumber", entity.SerialNumber);
        //    parameters.Add("@GradeCompany", entity.GradeCompany);
        //    parameters.Add("@Grade", entity.Grade);
        //    parameters.Add("@IsRookie", entity.IsRookie);
        //    parameters.Add("@IsAuto", entity.IsAutograph);
        //    parameters.Add("@IsPatch", entity.IsPatch);
        //    parameters.Add("@IsOnCardAuto", entity.IsOnCardAutograph);
        //    parameters.Add("@IsGameWornJersey", entity.IsGameWornJersey);
        //    parameters.Add("@SportId", entity.SportId);
        //    var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
        //    using (var connection = _connectionFactory.CreateConnection())
        //    {
        //        return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
        //    }
        //}

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
    }
}
