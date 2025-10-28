# ================================
# PowerShell Script: Run API + LocalTunnel (port 5228)
# Features:
#  Start ASP.NET Core API
#  Open LocalTunnel
#  Copy public URL to clipboard
#  Open Swagger UI automatically
# ================================

$port = 5228
$subdomain = "mindmapmath5228"

Write-Host " Starting MindmapMathAPI on port $port..." -ForegroundColor Cyan

# 🔹 Kiểm tra port có đang bị chiếm không
$portInUse = Get-NetTCPConnection -LocalPort $port -ErrorAction SilentlyContinue
if ($portInUse) {
    Write-Host " Port $port is already in use. Please close other app using it!" -ForegroundColor Red
    exit
}

# 🔹 Chạy ASP.NET Core API trong cửa sổ nền
Start-Process powershell -ArgumentList "dotnet run --project .\MindmapMathAPI\MindmapMathAPI.csproj" -WindowStyle Minimized

# 🔹 Chờ API khởi động (8 giây)
Start-Sleep -Seconds 8

Write-Host " Opening LocalTunnel for port $port..." -ForegroundColor Green

#  Chạy localtunnel và đọc URL output
$ltProcess = Start-Process "cmd.exe" -ArgumentList "/c lt --port $port --subdomain $subdomain" -RedirectStandardOutput "lt_output.txt" -NoNewWindow -PassThru

#  Chờ localtunnel in ra URL (5 giây)
Start-Sleep -Seconds 5

#  Đọc URL từ file log
$url = Get-Content "lt_output.txt" | Select-String -Pattern "https://.*\.loca\.lt" | Select-Object -First 1
if ($url) {
    $publicUrl = $url.Matches.Value
    Write-Host " Tunnel ready: $publicUrl" -ForegroundColor Yellow

    #  Copy URL vào clipboard
    Set-Clipboard $publicUrl
    Write-Host " Copied public URL to clipboard." -ForegroundColor Cyan

    #  Mở Swagger UI trên trình duyệt
    $swaggerUrl = "$publicUrl/swagger"
    Write-Host " Opening Swagger UI: $swaggerUrl" -ForegroundColor Green
    Start-Process $swaggerUrl
}
else {
    Write-Host " Failed to detect LocalTunnel URL. Check if lt is installed globally (npm install -g localtunnel)" -ForegroundColor Red
}

Write-Host " Press Ctrl + C to stop API and tunnel manually." -ForegroundColor DarkGray
