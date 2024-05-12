FROM ubuntu:jammy-20240427

RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install \
        tzdata \
        wget \
        git \
        libicu-dev

# タイムゾーンの設定
RUN ln -fs /usr/share/zoneinfo/Asia/Tokyo /etc/localtime \
    && dpkg-reconfigure -f noninteractive tzdata

# .NET 8 SDK のインストール ※要 libicu-dev
RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh \
    && chmod +x ./dotnet-install.sh \
    && mkdir -p /usr/lib/dotnet \
    && ./dotnet-install.sh --version 8.0.204 --install-dir /usr/lib/dotnet \
    && rm ./dotnet-install.sh
ENV PATH="${PATH}:/usr/lib/dotnet"