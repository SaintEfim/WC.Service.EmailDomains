using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.EmailDomains.API.Models;
using WC.Service.EmailDomains.Domain.Models;
using WC.Service.EmailDomains.Domain.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.EmailDomains.API.Controllers;

/// <summary>
///     The email domain management controller.
/// </summary>
[Route("api/v1/email-domains")]
public class EmailDomainController
    : CrudApiControllerBase<EmailDomainController, IEmailDomainManager, IEmailDomainProvider, EmailDomainModel,
        EmailDomainDto>
{
    /// <inheritdoc/>
    public EmailDomainController(
        IMapper mapper,
        ILogger<EmailDomainController> logger,
        IEmailDomainManager manager,
        IEmailDomainProvider provider)
        : base(mapper, logger, manager, provider)
    {
    }

    /// <summary>
    ///     Retrieves a list of email domains.
    /// </summary>
    /// <param name="withIncludes">Specifies whether related entities should be included in the query.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpGet]
    [OpenApiOperation(nameof(EmailDomainGet))]
    [SwaggerResponse(Status200OK, typeof(List<EmailDomainDto>))]
    public async Task<ActionResult<List<EmailDomainDto>>> EmailDomainGet(
        bool withIncludes = false,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(withIncludes, cancellationToken: cancellationToken));
    }

    /// <summary>
    ///     Retrieves a email domain by its ID.
    /// </summary>
    /// <param name="id">The ID of the email domain to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpGet("{id:guid}", Name = nameof(EmailDomainGetById))]
    [Authorize(Roles = "Admin")]
    [OpenApiOperation(nameof(EmailDomainGetById))]
    [SwaggerResponse(Status200OK, typeof(EmailDomainDto))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public async Task<ActionResult<EmailDomainDto>> EmailDomainGetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, true, cancellationToken: cancellationToken));
    }

    /// <summary>
    ///     Creates new email domain.
    /// </summary>
    /// <param name="payload">The email domain content.</param>
    /// <param name="cancellationToken">The operation cancellation token</param>
    /// <returns>The result of creation. <see cref="CreateActionResultDto"/></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [OpenApiOperation(nameof(EmailDomainCreate))]
    [SwaggerResponse(Status201Created, typeof(CreateActionResultDto))]
    public Task<IActionResult> EmailDomainCreate(
        [FromBody] EmailDomainCreateDto payload,
        CancellationToken cancellationToken = default)
    {
        return Create<EmailDomainCreateDto, CreateActionResultDto>(payload, nameof(EmailDomainGetById),
            cancellationToken);
    }

    /// <summary>
    ///     Updates a email domain by ID.
    /// </summary>
    /// <param name="id">The ID of the email domain to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [OpenApiOperation(nameof(EmailDomainUpdate))]
    [SwaggerResponse(Status200OK, typeof(void))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public async Task<IActionResult> EmailDomainUpdate(
        Guid id,
        [FromBody] JsonPatchDocument<EmailDomainUpdateDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken: cancellationToken));
    }

    /// <summary>
    ///     Deletes a email domain by ID.
    /// </summary>
    /// <param name="id">The ID of the email domain to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [OpenApiOperation(nameof(EmailDomainDelete))]
    [SwaggerResponse(Status204NoContent, typeof(void))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, typeof(ErrorDto))]
    public async Task<IActionResult> EmailDomainDelete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await Delete(id, cancellationToken: cancellationToken);
    }
}
