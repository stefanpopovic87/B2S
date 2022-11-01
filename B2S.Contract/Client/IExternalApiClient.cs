namespace B2S.Contract.Client
{
    public interface IExternalApiClient
    {
        Task<GetCourseDetailsResponse> GetCourseDetailsAsync(long code);
    }
}
