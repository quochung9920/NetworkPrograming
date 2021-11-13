﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeNet;

namespace CSampleServer
{
	class Program
	{
		static List<CGameUser> userlist;

		static void Main(string[] args)
		{
			userlist = new List<CGameUser>();

			CNetworkService service = new CNetworkService(false);
			// 콜백 매소드 설정.
			service.session_created_callback += on_session_created;
			// 초기화.
			service.initialize(10000, 1024);
			service.listen("0.0.0.0", 7979, 100);

            // 서버에서 하트비트 체크를 끌때 사용함.
            // 스트레스 테스트를 하기 위해 FreeNet이 아닌 다른 클라이언트를 쓰는 경우등에 필요할것 같다.
            // Remove below comments to disable heartbeat on server.
            // (It maybe use to stress test from another client program not using FreeNet.)
            //service.disable_heartbeat();


			Console.WriteLine("Started!");
			while (true)
			{
                //Console.Write(".");
                string input = Console.ReadLine();
                if (input.Equals("users"))
                {
                    Console.WriteLine(service.usermanager.get_total_count());
                }
				System.Threading.Thread.Sleep(1000);
			}

			//Console.ReadKey();
		}

		/// <summary>
		/// 클라이언트가 접속 완료 하였을 때 호출됩니다.
		/// n개의 워커 스레드에서 호출될 수 있으므로 공유 자원 접근시 동기화 처리를 해줘야 합니다.
		/// </summary>
		/// <returns></returns>
		static void on_session_created(CUserToken token)
		{
            CGameUser user = new CGameUser(token);
            lock (userlist)
            {
                userlist.Add(user);
            }
        }

		public static void remove_user(CGameUser user)
		{
            lock (userlist)
            {
                userlist.Remove(user);
            }
        }
	}
}
