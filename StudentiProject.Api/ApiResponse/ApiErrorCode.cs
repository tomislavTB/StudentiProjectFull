namespace StudentiProject.ApiResponse
{
    public enum ApiErrorCode
    {
        SYSTEM = 1,
        
        AUTHENTICATION = 2,

        VALIDATION = 3,
        
        NOT_FOUND = 4,

        // bi error, domain language error
        DOMAIN = 5
    }
}