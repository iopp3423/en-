package use;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.io.DataOutputStream;
import java.net.URLEncoder;

public class test {

	public void api()
	{
		try {
		String apikey = "{26a41b7bfe87ed292acb3bbb3f064df6}";	    
		
		String apiURL = "https://dapi.kakao.com/v2/search/image.json?query=설현";
		URL url = new URL(apiURL);
		HttpURLConnection con = (HttpURLConnection)url.openConnection();
		String userCredentials = apikey;
		String basicAuth = "KakaoAK" + userCredentials;
		con.setRequestMethod("GET");
		con.setRequestProperty("Authorization:",basicAuth);
		con.setRequestProperty("Content-type", "application/json");
		con.setUseCaches(false);
		con.setDoInput(true);
		con.setDoOutput(true);
		int responseCode = con.getResponseCode();
		System.out.println("responseCode >> " + responseCode);
		BufferedReader br;
		if(responseCode == 200) {
			br = new BufferedReader(new InputStreamReader(con.getInputStream()));
		}
		else {
			br = new BufferedReader(new InputStreamReader(con.getErrorStream()));
		}
			String inputLine;
			StringBuffer res = new StringBuffer();
			while((inputLine = br.readLine()) != null)
			{
				res.append(inputLine);
			}
			br.close();
			System.out.println("응답 결과 >>  "+res.toString());
		}
		catch(Exception e)
		{
			System.out.println("오류발생");
		}
		
		
	
	}
//	/{26a41b7bfe87ed292acb3bbb3f064df6}
	
	public void apiTestGet() throws Exception 
	{
	    URL url = null;
	    String readLine = null;
	    StringBuilder buffer = null;
	    BufferedReader bufferedReader = null;
	    BufferedWriter bufferedWriter = null;
	    HttpURLConnection urlConnection = null;
	    	
	    int connTimeout = 5000;
	    int readTimeout = 3000;
			
	    String apiUrl = "https://dapi.kakao.com/v2/search/image?query=설현";	// 각자 상황에 맞는 IP & url 사용 		
			
	    try 
	    {
	        url = new URL(apiUrl);
	        
	        urlConnection = (HttpURLConnection)url.openConnection();
	        urlConnection.setRequestMethod("GET"); // GET 있었
	        urlConnection.setConnectTimeout(connTimeout);
	        urlConnection.setReadTimeout(readTimeout);
	        urlConnection.setRequestProperty("Accept", "application/json;");
				
	        buffer = new StringBuilder();
	        
	        if(urlConnection.getResponseCode() == HttpURLConnection.HTTP_OK) 
	        {
	            bufferedReader = new BufferedReader(new InputStreamReader(urlConnection.getInputStream(),"UTF-8"));
	            while((readLine = bufferedReader.readLine()) != null) 
	    	    {
	                buffer.append(readLine).append("\n");
	            }
	        }
	        else
	        {
	            buffer.append("code : ");
	            buffer.append(urlConnection.getResponseCode()).append("\n");
	            buffer.append("message : ");
	            buffer.append(urlConnection.getResponseMessage()).append("\n");
	        }
	    }
	    catch(Exception ex) 
	    {
	        ex.printStackTrace();
	    }
	    finally 
	    {
	        try 
	        {
	            if (bufferedWriter != null) { bufferedWriter.close(); }
	            if (bufferedReader != null) { bufferedReader.close(); }
	        }
	        catch(Exception ex) 
	        { 
	            ex.printStackTrace();
	        }
	    }
			
			
	        System.out.println("결과 : " + buffer.toString());
	    }
	
	static final String BASE_URL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size=10&query=설현";
	//"https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size="+comboboxNumber+"&query="설현 "
	//static final String AUTH_TOKEN = "AUTH_TOKEN 값";
	//static String AUTH_KEY = "Bearer " + "AUTH_KEY 값";
	public void testt()
	{

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
				System.out.println("\n");
			}
			
			con.disconnect();
		}catch(Exception e) {
			e.printStackTrace();
		}

			
	}
	    
}
