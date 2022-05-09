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
import javax.imageio.ImageIO;



public class test {


	public void testt(String size, String name)
	{
		size = "10";
		String BASE_URL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size="+ size + "&query=" + name;
		
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
			}
		
			con.disconnect();
		}catch(Exception e) {
			e.printStackTrace();
		}
		
				
			try {
				result = (JSONObject) new JSONParser().parse(sb.toString());
			} catch (ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			StringBuilder out = new StringBuilder();
			out.append(result.get("status") +" : " + result.get("status_message") +"\n");
				
	
			
			// JSONObject에서 Array데이터를 get하여 JSONArray에 저장한다.
			JSONArray array = (JSONArray) result.get("documents");

				
			out.append("데이터 출력하기 \n");
			for(int i=0; i<array.size(); i++) {		
				JSONObject arr = (JSONObject)array.get(i);
				System.out.println(arr.get("image_url"));
				out.append("\n");
			}

	
	
	}	    
	
}