#!/usr/bin/pwsh

$domain = "http://localhost:2003"

$domain = "http://localhost:8003"

Invoke-RestMethod `
    -Uri "$domain/api/ping"
 
# values are arbitrary
$headers = @{
    user_id="e727c9b6-5498-405c-aafc-bf8d8e8fb61d"
    transaction_id = "5047e2e0-2f03-46b4-82a0-216e180dea4f"
}

try
{
    $response = Invoke-WebRequest `
        -Uri "$domain/api/authcheck" 
    # This will only execute if the Invoke-WebRequest is successful.
    $StatusCode = $Response.StatusCode
}
catch
{
    $StatusCode = $_.Exception.Response.StatusCode.value__
}
if ($StatusCode -ne 401) { throw "authcheck should have returned 401 without headers"
} else { 
Write-Host "Call returned 401 as expected" }

# Succeed with headers
Invoke-RestMethod `
    -Uri "$domain/api/authcheck" `
    -Headers $headers


# Gets values from a database
Invoke-RestMethod `
    -Uri "$domain/api/values" 


# Gets values from a database
Invoke-RestMethod `
    -Uri "$domain/api/actionitems" 

# Problems? Try these:
# * Verify that the database container is running
# * Verify that the database is on the expected network (docker network)
# * Verify that the connection string is correct
# * Verify that the service is pulling the correct configuration files




