#region References
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
#endregion

namespace Ultima
{
	public sealed class Map
	{
		private TileMatrix m_Tiles;
		private readonly string m_path;

		private static bool m_UseDiff;

		public static bool UseDiff
		{
			get => m_UseDiff;
			set
			{
				m_UseDiff = value;
				Reload();
			}
		}

		public static Map Felucca = new Map(0, 0, 6144, 4096);
		public static Map Trammel = new Map(0, 1, 6144, 4096);
		public static Map Ilshenar = new Map(2, 2, 2304, 1600);
		public static Map Malas = new Map(3, 3, 2560, 2048);
		public static Map Tokuno = new Map(4, 4, 1448, 1448);
		public static Map TerMur = new Map(5, 5, 1280, 4096);

		public static IEnumerable<Map> Maps
		{
			get
			{
				yield return Felucca;
				yield return Trammel;
				yield return Ilshenar;
				yield return Malas;
				yield return Tokuno;
				yield return TerMur;
			}
		}

		public static void StartUpSetDiff(bool value)
		{
			m_UseDiff = value;
		}

		public Map(int fileIndex, int mapID, int width, int height)
		{
			FileIndex = fileIndex;
			MapID = mapID;
			Width = width;
			Height = height;
			m_path = null;
		}

		public Map(string path, int fileIndex, int mapID, int width, int height)
		{
			FileIndex = fileIndex;
			MapID = mapID;
			Width = width;
			Height = height;
			m_path = path;
		}

		/// <summary>
		///     Sets cache-vars to null
		/// </summary>
		public static void Reload()
		{
			foreach (var map in Maps)
			{
				map.Tiles.StaticIndexInit = false;
				
				map.Tiles.Dispose();
				
				map.m_Tiles = null;
				map.m_Cache = null;
				map.m_Cache_NoStatics = null;
				map.m_Cache_NoPatch = null;
				map.m_Cache_NoStatics_NoPatch = null;
			}
		}

		public void ResetCache()
		{
			m_Cache = null;
			m_Cache_NoPatch = null;
			m_Cache_NoStatics = null;
			m_Cache_NoStatics_NoPatch = null;
			IsCached_Default = false;
			IsCached_NoStatics = false;
			IsCached_NoPatch = false;
			IsCached_NoStatics_NoPatch = false;
		}

		public bool LoadedMatrix => m_Tiles != null;

		public TileMatrix Tiles
		{
			get
			{
				if (m_Tiles == null)
				{
					m_Tiles = new TileMatrix(FileIndex, MapID, Width, Height, m_path);
				}

				return m_Tiles;
			}
		}

		public int Width { get; set; }

		public int Height { get; }

		public int FileIndex { get; }

		public int MapID { get; }

		/// <summary>
		///     Returns Bitmap with Statics
		/// </summary>
		/// <param name="x">8x8 Block</param>
		/// <param name="y">8x8 Block</param>
		/// <param name="width">8x8 Block</param>
		/// <param name="height">8x8 Block</param>
		/// <returns></returns>
		public Bitmap GetImage(int x, int y, int width, int height)
		{
			return GetImage(x, y, width, height, true);
		}

		/// <summary>
		///     Returns Bitmap
		/// </summary>
		/// <param name="x">8x8 Block</param>
		/// <param name="y">8x8 Block</param>
		/// <param name="width">8x8 Block</param>
		/// <param name="height">8x8 Block</param>
		/// <param name="statics">8x8 Block</param>
		/// <returns></returns>
		public Bitmap GetImage(int x, int y, int width, int height, bool statics)
		{
			var bmp = new Bitmap(width << 3, height << 3, PixelFormat.Format16bppRgb555);

			GetImage(x, y, width, height, bmp, statics);

			return bmp;
		}

		private bool IsCached_Default;
		private bool IsCached_NoStatics;
		private bool IsCached_NoPatch;
		private bool IsCached_NoStatics_NoPatch;

		private short[][][] m_Cache;
		private short[][][] m_Cache_NoStatics;
		private short[][][] m_Cache_NoPatch;
		private short[][][] m_Cache_NoStatics_NoPatch;
		private short[] m_Black;

		public bool IsCached(bool statics)
		{
			if (UseDiff)
			{
				if (!statics)
				{
					return IsCached_NoStatics;
				}
				
				return IsCached_Default;
			}
			
			if (!statics)
			{
				return IsCached_NoStatics_NoPatch;
			}
				
			return IsCached_NoPatch;
		}

		public void PreloadRenderedBlock(int x, int y, bool statics)
		{
			var matrix = Tiles;

			if (x < 0 || y < 0 || x >= matrix.BlockWidth || y >= matrix.BlockHeight)
			{
				if (m_Black == null)
				{
					m_Black = new short[64];
				}
				return;
			}

			short[][][] cache;
			if (UseDiff)
			{
				if (statics)
				{
					IsCached_Default = true;
				}
				else
				{
					IsCached_NoStatics = true;
				}
				cache = statics ? m_Cache : m_Cache_NoStatics;
			}
			else
			{
				if (statics)
				{
					IsCached_NoPatch = true;
				}
				else
				{
					IsCached_NoStatics_NoPatch = true;
				}
				cache = statics ? m_Cache_NoPatch : m_Cache_NoStatics_NoPatch;
			}

			if (cache == null)
			{
				if (UseDiff)
				{
					if (statics)
					{
						m_Cache = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
				else
				{
					if (statics)
					{
						m_Cache_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
			}

			if (cache[y] == null)
			{
				cache[y] = new short[m_Tiles.BlockWidth][];
			}

			if (cache[y][x] == null)
			{
				cache[y][x] = RenderBlock(x, y, statics, UseDiff);
			}

			m_Tiles.CloseStreams();
		}

		private short[] GetRenderedBlock(int x, int y, bool statics)
		{
			var matrix = Tiles;

			if (x < 0 || y < 0 || x >= matrix.BlockWidth || y >= matrix.BlockHeight)
			{
				if (m_Black == null)
				{
					m_Black = new short[64];
				}

				return m_Black;
			}

			short[][][] cache;
			if (UseDiff)
			{
				cache = statics ? m_Cache : m_Cache_NoStatics;
			}
			else
			{
				cache = statics ? m_Cache_NoPatch : m_Cache_NoStatics_NoPatch;
			}

			if (cache == null)
			{
				if (UseDiff)
				{
					if (statics)
					{
						m_Cache = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
				else
				{
					if (statics)
					{
						m_Cache_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
			}

			if (cache[y] == null)
			{
				cache[y] = new short[m_Tiles.BlockWidth][];
			}

			var data = cache[y][x];

			if (data == null)
			{
				cache[y][x] = data = RenderBlock(x, y, statics, UseDiff);
			}

			return data;
		}

		private unsafe short[] RenderBlock(int x, int y, bool drawStatics, bool diff)
		{
			var data = new short[64];

			var tiles = m_Tiles.GetLandBlock(x, y, diff);

			fixed (short* pColors = RadarCol.Colors)
			{
				fixed (int* pHeight = TileData.HeightTable)
				{
					fixed (Tile* ptTiles = tiles)
					{
						var pTiles = ptTiles;

						fixed (short* pData = data)
						{
							var pvData = pData;

							if (drawStatics)
							{
								var statics = drawStatics ? m_Tiles.GetStaticBlock(x, y, diff) : null;

								for (int k = 0, v = 0; k < 8; ++k, v += 8)
								{
									for (var p = 0; p < 8; ++p)
									{
										var highTop = -255;
										var highZ = -255;
										var highID = 0;
										var highHue = 0;
										int z, top;
										var highstatic = false;

										var curStatics = statics[p][k];

										if (curStatics.Length > 0)
										{
											fixed (HuedTile* phtStatics = curStatics)
											{
												var pStatics = phtStatics;
												var pStaticsEnd = pStatics + curStatics.Length;

												while (pStatics < pStaticsEnd)
												{
													z = pStatics->m_Z;
													top = z + pHeight[pStatics->ID];

													if (top > highTop || (z > highZ && top >= highTop))
													{
														highTop = top;
														highZ = z;
														highID = pStatics->ID;
														highHue = pStatics->Hue;
														highstatic = true;
													}

													++pStatics;
												}
											}
										}
										var pending = m_Tiles.GetPendingStatics(x, y);
										if (pending != null)
										{
											foreach (var penS in pending)
											{
												if (penS.m_X == p)
												{
													if (penS.m_Y == k)
													{
														z = penS.m_Z;
														top = z + pHeight[penS.m_ID];

														if (top > highTop || (z > highZ && top >= highTop))
														{
															highTop = top;
															highZ = z;
															highID = penS.m_ID;
															highHue = penS.m_Hue;
															highstatic = true;
														}
													}
												}
											}
										}

										top = pTiles->m_Z;

										if (top > highTop)
										{
											highID = pTiles->m_ID;
											highHue = 0;
											highstatic = false;
										}

										if (highHue == 0)
										{
											try
											{
												if (highstatic)
												{
													*pvData++ = pColors[highID + 0x4000];
												}
												else
												{
													*pvData++ = pColors[highID];
												}
											}
											catch
											{ }
										}
										else
										{
											*pvData++ = Hues.GetHue(highHue - 1).Colors[(pColors[highID + 0x4000] >> 10) & 0x1F];
										}

										++pTiles;
									}
								}
							}
							else
							{
								var pEnd = pTiles + 64;

								while (pTiles < pEnd)
								{
									*pvData++ = pColors[pTiles++->m_ID];
								}
							}
						}
					}
				}
			}

			return data;
		}

		/// <summary>
		///     Draws in given Bitmap with Statics
		/// </summary>
		/// <param name="x">8x8 Block</param>
		/// <param name="y">8x8 Block</param>
		/// <param name="width">8x8 Block</param>
		/// <param name="height">8x8 Block</param>
		/// <param name="bmp">8x8 Block</param>
		public void GetImage(int x, int y, int width, int height, Bitmap bmp)
		{
			GetImage(x, y, width, height, bmp, true);
		}

		/// <summary>
		///     Draws in given Bitmap
		/// </summary>
		/// <param name="x">8x8 Block</param>
		/// <param name="y">8x8 Block</param>
		/// <param name="width">8x8 Block</param>
		/// <param name="height">8x8 Block</param>
		/// <param name="bmp"></param>
		/// <param name="statics"></param>
		public unsafe void GetImage(int x, int y, int width, int height, Bitmap bmp, bool statics)
		{
			var bd = bmp.LockBits(new Rectangle(0, 0, width << 3, height << 3), ImageLockMode.WriteOnly, PixelFormat.Format16bppRgb555);
			var stride = bd.Stride;
			var blockStride = stride << 3;

			var pStart = (byte*)bd.Scan0;

			for (int oy = 0, by = y; oy < height; ++oy, ++by, pStart += blockStride)
			{
				var pRow0 = (int*)(pStart + (0 * stride));
				var pRow1 = (int*)(pStart + (1 * stride));
				var pRow2 = (int*)(pStart + (2 * stride));
				var pRow3 = (int*)(pStart + (3 * stride));
				var pRow4 = (int*)(pStart + (4 * stride));
				var pRow5 = (int*)(pStart + (5 * stride));
				var pRow6 = (int*)(pStart + (6 * stride));
				var pRow7 = (int*)(pStart + (7 * stride));

				for (int ox = 0, bx = x; ox < width; ++ox, ++bx)
				{
					var data = GetRenderedBlock(bx, by, statics);

					fixed (short* pData = data)
					{
						var pvData = (int*)pData;

						*pRow0++ = *pvData++;
						*pRow0++ = *pvData++;
						*pRow0++ = *pvData++;
						*pRow0++ = *pvData++;

						*pRow1++ = *pvData++;
						*pRow1++ = *pvData++;
						*pRow1++ = *pvData++;
						*pRow1++ = *pvData++;

						*pRow2++ = *pvData++;
						*pRow2++ = *pvData++;
						*pRow2++ = *pvData++;
						*pRow2++ = *pvData++;

						*pRow3++ = *pvData++;
						*pRow3++ = *pvData++;
						*pRow3++ = *pvData++;
						*pRow3++ = *pvData++;

						*pRow4++ = *pvData++;
						*pRow4++ = *pvData++;
						*pRow4++ = *pvData++;
						*pRow4++ = *pvData++;

						*pRow5++ = *pvData++;
						*pRow5++ = *pvData++;
						*pRow5++ = *pvData++;
						*pRow5++ = *pvData++;

						*pRow6++ = *pvData++;
						*pRow6++ = *pvData++;
						*pRow6++ = *pvData++;
						*pRow6++ = *pvData++;

						*pRow7++ = *pvData++;
						*pRow7++ = *pvData++;
						*pRow7++ = *pvData++;
						*pRow7++ = *pvData++;
					}
				}
			}

			bmp.UnlockBits(bd);
			m_Tiles.CloseStreams();
		}

		public static void DefragStatics(string path, Map map, int width, int height, bool remove)
		{
			var indexPath = Files.GetFilePath("staidx{0}.mul", map.FileIndex);
			FileStream m_Index;
			BinaryReader m_IndexReader;
			if (indexPath != null)
			{
				m_Index = new FileStream(indexPath, FileMode.Open, FileAccess.Read, FileShare.Read);
				m_IndexReader = new BinaryReader(m_Index);
			}
			else
			{
				return;
			}

			var staticsPath = Files.GetFilePath("statics{0}.mul", map.FileIndex);

			FileStream m_Statics;
			BinaryReader m_StaticsReader;
			if (staticsPath != null)
			{
				m_Statics = new FileStream(staticsPath, FileMode.Open, FileAccess.Read, FileShare.Read);
				m_StaticsReader = new BinaryReader(m_Statics);
			}
			else
			{
				return;
			}

			var blockx = width >> 3;
			var blocky = height >> 3;

			var idx = Path.Combine(path, String.Format("staidx{0}.mul", map.FileIndex));
			var mul = Path.Combine(path, String.Format("statics{0}.mul", map.FileIndex));
			using (FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
							  fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write))
			{
				var memidx = new MemoryStream();
				var memmul = new MemoryStream();
				using (BinaryWriter binidx = new BinaryWriter(memidx), binmul = new BinaryWriter(memmul))
				{
					for (var x = 0; x < blockx; ++x)
					{
						for (var y = 0; y < blocky; ++y)
						{
							try
							{
								_ = m_IndexReader.BaseStream.Seek(((x * blocky) + y) * 12, SeekOrigin.Begin);
								var lookup = m_IndexReader.ReadInt32();
								var length = m_IndexReader.ReadInt32();
								var extra = m_IndexReader.ReadInt32();

								if (((lookup < 0 || length <= 0) && (!map.Tiles.PendingStatic(x, y))) || map.Tiles.IsStaticBlockRemoved(x, y))
								{
									binidx.Write(-1); // lookup
									binidx.Write(-1); // length
									binidx.Write(-1); // extra
								}
								else
								{
									if ((lookup >= 0) && (length > 0))
									{
										_ = m_Statics.Seek(lookup, SeekOrigin.Begin);
									}

									var fsmullength = (int)binmul.BaseStream.Position;
									var count = length / 7;
									if (!remove) //without duplicate remove
									{
										var firstitem = true;
										for (var i = 0; i < count; ++i)
										{
											var graphic = m_StaticsReader.ReadUInt16();
											var sx = m_StaticsReader.ReadByte();
											var sy = m_StaticsReader.ReadByte();
											var sz = m_StaticsReader.ReadSByte();
											var shue = m_StaticsReader.ReadInt16();
											if ((graphic >= 0) && (graphic <= Art.GetMaxItemID()))
											{
												if (shue < 0)
												{
													shue = 0;
												}
												if (firstitem)
												{
													binidx.Write((int)binmul.BaseStream.Position); //lookup
													firstitem = false;
												}
												binmul.Write(graphic);
												binmul.Write(sx);
												binmul.Write(sy);
												binmul.Write(sz);
												binmul.Write(shue);
											}
										}
										var tilelist = map.Tiles.GetPendingStatics(x, y);
										if (tilelist != null)
										{
											for (var i = 0; i < tilelist.Length; ++i)
											{
												if ((tilelist[i].m_ID >= 0) && (tilelist[i].m_ID <= Art.GetMaxItemID()))
												{
													if (tilelist[i].m_Hue < 0)
													{
														tilelist[i].m_Hue = 0;
													}
													if (firstitem)
													{
														binidx.Write((int)binmul.BaseStream.Position); //lookup
														firstitem = false;
													}
													binmul.Write(tilelist[i].m_ID);
													binmul.Write(tilelist[i].m_X);
													binmul.Write(tilelist[i].m_Y);
													binmul.Write(tilelist[i].m_Z);
													binmul.Write(tilelist[i].m_Hue);
												}
											}
										}
									}
									else //with duplicate remove
									{
										var tilelist = new StaticTile[count];
										var j = 0;
										for (var i = 0; i < count; ++i)
										{
											var tile = new StaticTile
											{
												m_ID = m_StaticsReader.ReadUInt16(),
												m_X = m_StaticsReader.ReadByte(),
												m_Y = m_StaticsReader.ReadByte(),
												m_Z = m_StaticsReader.ReadSByte(),
												m_Hue = m_StaticsReader.ReadInt16()
											};

											if ((tile.m_ID >= 0) && (tile.m_ID <= Art.GetMaxItemID()))
											{
												if (tile.m_Hue < 0)
												{
													tile.m_Hue = 0;
												}
												var first = true;
												for (var k = 0; k < j; ++k)
												{
													if ((tilelist[k].m_ID == tile.m_ID) && (tilelist[k].m_X == tile.m_X) && (tilelist[k].m_Y == tile.m_Y) &&
														(tilelist[k].m_Z == tile.m_Z) && (tilelist[k].m_Hue == tile.m_Hue))
													{
														first = false;
														break;
													}
												}
												if (first)
												{
													tilelist[j] = tile;
													j++;
												}
											}
										}
										if (map.Tiles.PendingStatic(x, y))
										{
											var pending = map.Tiles.GetPendingStatics(x, y);
											var old = tilelist;
											tilelist = new StaticTile[old.Length + pending.Length];
											old.CopyTo(tilelist, 0);
											for (var i = 0; i < pending.Length; ++i)
											{
												if ((pending[i].m_ID >= 0) && (pending[i].m_ID <= Art.GetMaxItemID()))
												{
													if (pending[i].m_Hue < 0)
													{
														pending[i].m_Hue = 0;
													}
													var first = true;
													for (var k = 0; k < j; ++k)
													{
														if ((tilelist[k].m_ID == pending[i].m_ID) &&
															(tilelist[k].m_X == pending[i].m_X) && (tilelist[k].m_Y == pending[i].m_Y) &&
															(tilelist[k].m_Z == pending[i].m_Z) && (tilelist[k].m_Hue == pending[i].m_Hue))
														{
															first = false;
															break;
														}
													}
													if (first)
													{
														tilelist[j++] = pending[i];
													}
												}
											}
										}
										if (j > 0)
										{
											binidx.Write((int)binmul.BaseStream.Position); //lookup
											for (var i = 0; i < j; ++i)
											{
												binmul.Write(tilelist[i].m_ID);
												binmul.Write(tilelist[i].m_X);
												binmul.Write(tilelist[i].m_Y);
												binmul.Write(tilelist[i].m_Z);
												binmul.Write(tilelist[i].m_Hue);
											}
										}
									}

									fsmullength = (int)binmul.BaseStream.Position - fsmullength;
									if (fsmullength > 0)
									{
										binidx.Write(fsmullength); //length
										if (extra == -1)
										{
											extra = 0;
										}
										binidx.Write(extra); //extra
									}
									else
									{
										binidx.Write(-1); //lookup
										binidx.Write(-1); //length
										binidx.Write(-1); //extra
									}
								}
							}
							catch // fill the rest
							{
								_ = binidx.BaseStream.Seek(((x * blocky) + y) * 12, SeekOrigin.Begin);
								for (; x < blockx; ++x)
								{
									for (; y < blocky; ++y)
									{
										binidx.Write(-1); //lookup
										binidx.Write(-1); //length
										binidx.Write(-1); //extra
									}
									y = 0;
								}
							}
						}
					}
					memidx.WriteTo(fsidx);
					memmul.WriteTo(fsmul);
				}
			}
			m_IndexReader.Close();
			m_StaticsReader.Close();
		}

		public static void RewriteMap(string path, int map, int width, int height)
		{
			var mapPath = Files.GetFilePath("map{0}.mul", map);
			FileStream m_map;
			BinaryReader m_mapReader;
			if (mapPath != null)
			{
				m_map = new FileStream(mapPath, FileMode.Open, FileAccess.Read, FileShare.Read);
				m_mapReader = new BinaryReader(m_map);
			}
			else
			{
				return;
			}

			var blockx = width >> 3;
			var blocky = height >> 3;

			var mul = Path.Combine(path, String.Format("map{0}.mul", map));
			using (var fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write))
			{
				var memmul = new MemoryStream();
				using (var binmul = new BinaryWriter(memmul))
				{
					for (var x = 0; x < blockx; ++x)
					{
						for (var y = 0; y < blocky; ++y)
						{
							try
							{
								_ = m_mapReader.BaseStream.Seek(((x * blocky) + y) * 196, SeekOrigin.Begin);
								var header = m_mapReader.ReadInt32();
								binmul.Write(header);
								for (var i = 0; i < 64; ++i)
								{
									var tileid = m_mapReader.ReadInt16();
									var z = m_mapReader.ReadSByte();
									if ((tileid < 0) || (tileid >= 0x4000))
									{
										tileid = 0;
									}
									if (z < -128)
									{
										z = -128;
									}
									if (z > 127)
									{
										z = 127;
									}
									binmul.Write(tileid);
									binmul.Write(z);
								}
							}
							catch //fill rest
							{
								_ = binmul.BaseStream.Seek(((x * blocky) + y) * 196, SeekOrigin.Begin);
								for (; x < blockx; ++x)
								{
									for (; y < blocky; ++y)
									{
										binmul.Write(0);
										for (var i = 0; i < 64; ++i)
										{
											binmul.Write((short)0);
											binmul.Write((sbyte)0);
										}
									}
									y = 0;
								}
							}
						}
					}
					memmul.WriteTo(fsmul);
				}
			}
			m_mapReader.Close();
		}

		public void ReportInvisStatics(string reportfile)
		{
			reportfile = Path.Combine(reportfile, String.Format("staticReport-{0}.csv", MapID));
			using (var Tex = new StreamWriter(new FileStream(reportfile, FileMode.Create, FileAccess.ReadWrite), Encoding.GetEncoding(1252)))
			{
				Tex.WriteLine("x;y;z;Static");
				for (var x = 0; x < Width; ++x)
				{
					for (var y = 0; y < Height; ++y)
					{
						var currtile = Tiles.GetLandTile(x, y);
						foreach (var currstatic in Tiles.GetStaticTiles(x, y))
						{
							if (currstatic.Z < currtile.Z)
							{
								if (TileData.ItemTable[currstatic.ID].Height + currstatic.Z < currtile.Z)
								{
									Tex.WriteLine(String.Format("{0};{1};{2};0x{3:X}", x, y, currstatic.Z, currstatic.ID));
								}
							}
						}
					}
				}
			}
		}

		public void ReportInvalidMapIDs(string reportfile)
		{
			reportfile = Path.Combine(reportfile, String.Format("ReportInvalidMapIDs-{0}.csv", MapID));
			using (var Tex = new StreamWriter(new FileStream(reportfile, FileMode.Create, FileAccess.ReadWrite), Encoding.GetEncoding(1252)))
			{
				Tex.WriteLine("x;y;z;Static;LandTile");
				for (var x = 0; x < Width; ++x)
				{
					for (var y = 0; y < Height; ++y)
					{
						var currtile = Tiles.GetLandTile(x, y);
						if (!Art.IsValidLand(currtile.ID))
						{
							Tex.WriteLine(String.Format("{0};{1};{2};0;0x{3:X}", x, y, currtile.Z, currtile.ID));
						}
						foreach (var currstatic in Tiles.GetStaticTiles(x, y))
						{
							if (!Art.IsValidStatic(currstatic.ID))
							{
								Tex.WriteLine(String.Format("{0};{1};{2};0x{3:X};0", x, y, currstatic.Z, currstatic.ID));
							}
						}
					}
				}
			}
		}
	}
}
