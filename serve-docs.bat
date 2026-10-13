@echo off
echo Starting MkDocs local server...
start "" /B mkdocs serve
timeout /t 3 /nobreak >nul
start http://127.0.0.1:8000
echo Server running. Press Ctrl+C to stop.
pause
