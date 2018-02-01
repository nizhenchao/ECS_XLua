
-- 字符串分割函数
-- 传入字符串和分隔符，返回分割后的table
function string.split(str, delimiter)
	if str == nil or str == '' or delimiter == nil then
		return nil
	end
	local result = { }
	for match in(str .. delimiter):gmatch("(.-)" .. delimiter) do
		table.insert(result, match)
	end
	return result
end

function string.splitNum(str, delimiter)
	if str == nil or str == '' or delimiter == nil then
		return nil
	end
	local result = { }
	for match in(str .. delimiter):gmatch("(.-)" .. delimiter) do
		local num = tonumber(match)
		table.insert(result, num)
	end
	return result
end