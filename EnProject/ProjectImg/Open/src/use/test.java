package use;


import java.io.*;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.io.DataOutputStream;
import java.net.URLEncoder;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;



public class test {

	static final String BASE_URL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size=1&query=설현";
	//"https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size="+comboboxNumber+"&query="설현 "
	//static final String AUTH_TOKEN = "AUTH_TOKEN 값";
	//static String AUTH_KEY = "Bearer " + "AUTH_KEY 값";
	public void testt()
	{
		JSONObject result = null;
		/**
		 *  REST API 호출하기
		 */
		URL url = null;
		HttpURLConnection con= null;
		StringBuilder sb = new StringBuilder();
		try {
			// URL 객채 생성 (BASE_URL)
			url = new URL(BASE_URL);
			// URL을 참조하는 객체를 URLConnection 객체로 변환
			con = (HttpURLConnection) url.openConnection();

			// 커넥션 request 방식 "GET"으로 설정
			con.setRequestMethod("GET");

			// 커넥션 request 값 설정(key,value) 
			con.setRequestProperty("Content-type", "application/json");
			// void setRequestProperty (key,value) 다른 예시
			 con.setRequestProperty("Authorization", "KakaoAK 26a41b7bfe87ed292acb3bbb3f064df6");
			// con.setRequestProperty("X-Auth-Token", AUTH_TOKEN);
			// 받아온 JSON 데이터 출력 가능 상태로 변경 (default : false)
			con.setDoOutput(true);

			// 데이터 입력 스트림에 담기
			BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream(), "UTF-8"));
			while(br.ready()) {
				sb.append(br.readLine());	
				System.out.println(sb);
				
			}
		
			con.disconnect();
		}catch(Exception e) {
			e.printStackTrace();
		}
		
				
			try {
				result = (JSONObject) new JSONParser().parse(sb.toString());
				System.out.println(result);
			} catch (ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			StringBuilder out = new StringBuilder();
			out.append(result.get("status") +" : " + result.get("status_message") +"\n");
				
	
			
			// JSONObject에서 Array데이터를 get하여 JSONArray에 저장한다.
			JSONArray array = (JSONArray) result.get("documents");
			//System.out.println(array);
			JSONObject arr = (JSONObject)array.get(0);
			
			System.out.println(arr.get("image_url"));
			out.append("데이터 출력하기 \n");
			//for(int i=0; i<array.size(); i++) {
			//	tmp = (JSONObject) array.get(i);
			//	out.append("title("+i+") :"+ tmp.get("image_url") +"\n");
			//	
			//	out.append("\n");
			//}

	
	
	}	    
	
}