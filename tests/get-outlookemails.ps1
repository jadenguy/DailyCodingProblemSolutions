Add-Type -assembly "Microsoft.Office.Interop.Outlook"
$Outlook = New-Object -comobject Outlook.Application
$current = $Outlook.GetNameSpace("MAPI")
$pathParts = @('jadenguy@gmail.com', 'inbox', 'dailycodingproblem')
foreach ($newPath in $pathParts) {
    $current = $current.Folders.Item($newPath) #| Where-Object -property FolderPath -eq $path | Select-Object -First 1
}
$Challenges = $current.Items | Sort-Object receivedtime

# $challenges | Select-Object subject, body |ConvertTo-Json|set-content dailycoding.json
. .\stringAssets.ps1

foreach ($challenge in $challenges) {
    try {
        $number = ( $challenge.Subject `
            | select-string -Pattern '\d+' `
            | Select-Object -ExpandProperty matches
        )[0].Value.PadLeft(3, '0')
        $description = ($challenge.Body `
            | select-string -Pattern  'Good morning(.*\r\n)*?(?=\r\n________________________________)' `
            | Select-Object -expandproperty matches
        )[0].Value
        $b2 = @()
        $description.Split("`n") | ForEach-Object { 
            $line = $_
            if ($line.ToCharArray().Length -gt 1) { $b2 += "// " + $line }
            # $b2 += "//" + $line;
        }
        $description = ($b2 | Select-Object -Skip 2 | Select-Object -SkipLast 1) -join "`n" 
        $filename = 'Test' + $number + ".cs"
        $content = $description + $start + $number + $middle + $number + $end
    }
    catch {
        $challenge.Subject | Write-Host
        $filename = $challenge.Subject + ".txt"
        $content = $challenge.Body
    }
    $content | Set-Content (".\import\" + $filename)
}