using System.Text.Json;
using WenawoMessenger.Client.Models.Token;

namespace WenawoMessenger.Client.Services.LocalStorage
{
	public class UserStorageService() : IUserStorageService
	{
		private readonly string path = Path.Combine(FileSystem.Current.AppDataDirectory, "tokens.json");

		public async Task<JwtTokens> ReadTokensAsync()
		{
			try
			{
				var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				var result = await JsonSerializer.DeserializeAsync<JwtTokens>(fileStream);
				fileStream.Close();
				if (result != null) return result;
				throw new Exception();
			}
			catch { throw new Exception(); }
		}

		public JwtTokens ReadToken()
		{
			try
			{
				var file = File.Open(path, FileMode.Open);
				var result = JsonSerializer.Deserialize<JwtTokens>(file);
				file.Close();
				if (result != null) return result;
				throw new Exception();
			}
			catch { throw new Exception(); }
		}

		public async Task SaveTokenAsync(JwtTokens tokens)
		{
			try
			{
				if (Directory.Exists(Path.GetDirectoryName(path))!)
					Directory.CreateDirectory(Path.GetDirectoryName(path)!);

				var filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
				await JsonSerializer.SerializeAsync(filestream, tokens);
				filestream.Close();
			}
			catch { throw new Exception(); }
		}

		public void SaveToken(JwtTokens tokens)
		{
			try
			{
				if (Directory.Exists(Path.GetDirectoryName(path)))
					Directory.CreateDirectory(Path.GetDirectoryName(path)!);

				var file = File.Create(path);
				JsonSerializer.Serialize(file, tokens);
				file.Close();
			}
			catch { throw new Exception(); }
		}

		public void Delete()
		{
			try
			{
				File.Delete(path);
			}
			catch { throw new Exception(); }
		}
	}
}
