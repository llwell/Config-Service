FROM microsoft/dotnet:2.1-runtime
WORKDIR /app
EXPOSE 80
ADD ACBC/obj/Docker/publish /app
RUN cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
ENTRYPOINT ["dotnet", "ConfigService.dll"]
