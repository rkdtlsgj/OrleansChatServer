# Orleans ChatRoom

Orleans을 알아보기 위해 공식문서를 보면서 공부한 채팅 예제<br>
원하는 채널에 입장하여 채널 참여자들끼리 채팅하는 프로젝트<br>

Orleans는 분산 서버를 만들때 사용하는 프레임워크<br>
Grain는 서버의 상태와 로직을 가진 단위 (예전에 만들었던 MMO_Server에서 jobsystem처럼 요청처리해주기 위함)<br>

# 환경
* .NET 8.0
* Microsoft Orleans (Silo/Client)
* Localhost clustering(개발용)

# 개발 목적
Orleans의 사용해보기 위해 Grain, Observer을 이용해서 채널과 브로드캐스트를 구현


# 구조
채널명 - Grain Key<br>
Dictionary를 이용해 채널 참가자를 관리


# 테스트
<img width="478" height="312" alt="image" src="https://github.com/user-attachments/assets/4a8f98be-121b-4844-95dd-b510affe63b8" />
